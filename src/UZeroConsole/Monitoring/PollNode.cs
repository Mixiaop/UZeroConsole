using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Profiling;

namespace UZeroConsole.Monitoring
{
    public abstract partial class PollNode : IMonitorStatus, IDisposable, IEquatable<PollNode>
    {
        #region Properties
        private int _totalPolls;
        private int _totalCacheSuccesses;
        private int _isPolling;
        private Cache _lastFetch;

        protected int PollFailsInaRow;
        protected int FailsBeforeBackoff => 3;
        protected virtual TimeSpan BackoffDuration => TimeSpan.FromSeconds(30);

        public string UniqueKey { get; }
        public bool AddedToGlobalPollers { get; private set; }
        public Cache LastFetch => _lastFetch;
        public DateTime? LastPoll { get; protected set; }
        public TimeSpan LastPollDuration { get; protected set; }
        public Stopwatch CurrentPollDuration { get; protected set; }

        public bool IsPolling => _isPolling > 0;
        public string PollStatus { get; protected set; } = "未启动";

        /// <summary>
        /// 此节点是否已完成过轮询
        /// </summary>
        public bool HasPolled => _totalPolls > 0;
        /// <summary>
        /// 此节点是否已完成过缓存轮询
        /// </summary>
        public bool HasPolledCacheSuccessfully => _totalCacheSuccesses > 0;

        /// <summary>
        /// 判断当前节点是否需要轮询
        /// </summary>
        public bool NeedsPoll
        {
            get
            {
                //不能小于轮询间隔 
                if (DateTime.Now < LastPoll.GetValueOrDefault().AddSeconds(MinSecondsBetweenPolls))
                {
                    return false;
                }

                //如果在行中看到轮询错误，则回退
                if (PollFailsInaRow >= FailsBeforeBackoff && DateTime.Now < LastPoll.GetValueOrDefault() + BackoffDuration)
                    return false;

                return true;
            }
        }

        protected abstract IEnumerable<MonitorStatus> GetMonitorStatus();
        protected abstract string GetMonitorStatusReason();
        public abstract string NodeType { get; }
        /// <summary>
        /// 节点最小的轮询间隔（秒）
        /// </summary>
        public abstract int MinSecondsBetweenPolls { get; }
        public abstract IEnumerable<Cache> DataPollers { get; }
        #endregion

        #region IMonitorStatus
        private readonly object _monitorStatusLock = new object();
        protected MonitorStatus? PreviousMonitorStatus;
        protected MonitorStatus? CachedMonitorStatus;
        public virtual MonitorStatus MonitorStatus
        {
            get
            {
                if (!CachedMonitorStatus.HasValue)
                {
                    lock (_monitorStatusLock)
                    {
                        if (CachedMonitorStatus.HasValue)
                            return CachedMonitorStatus.Value;

                        var pollers = DataPollers.Where(dp => dp.AffectsNodeStatus).ToList();
                        var fetchStatus = pollers.GetWorstStatus();
                        if (fetchStatus != MonitorStatus.Good)
                        {
                            CachedMonitorStatus = MonitorStatus.Critical;
                            MonitorStatusReason =
                                string.Join(", ", pollers.WithIssues()
                                                         .GroupBy(g => g.MonitorStatus)
                                                         .OrderByDescending(g => g.Key)
                                                         .Select(
                                                             g =>
                                                             g.Key + ": " + string.Join(", ", g.Select(p => p.ParentMemberName))
                                                      ));
                        }
                        else
                        {
                            CachedMonitorStatus = GetMonitorStatus().ToList().GetWorstStatus();
                            MonitorStatusReason = CachedMonitorStatus == MonitorStatus.Good ? null : GetMonitorStatusReason();
                        }
                        if (!PreviousMonitorStatus.HasValue || PreviousMonitorStatus != CachedMonitorStatus)
                        {
                            var handler = MonitorStatusChanged;
                            handler?.Invoke(this, new MonitorStatusArgs
                            {
                                OldMonitorStatus = PreviousMonitorStatus ?? MonitorStatus.Unknown,
                                NewMonitorStatus = CachedMonitorStatus.Value
                            });
                            PreviousMonitorStatus = CachedMonitorStatus;
                        }
                    }
                }
                return CachedMonitorStatus.GetValueOrDefault(MonitorStatus.Unknown);
            }
        }

        public string MonitorStatusReason { get; private set; }
        #endregion

        protected PollNode(string uniqueKey)
        {
            UniqueKey = uniqueKey;
        }

        internal void PollComplete(Cache cache, bool success)
        {
            Interlocked.Exchange(ref _lastFetch, cache);
            if (success)
            {
                Interlocked.Increment(ref _totalCacheSuccesses);
                Interlocked.Exchange(ref PollFailsInaRow, 0);
            }
            else
            {
                Interlocked.Increment(ref PollFailsInaRow);
            }
            CachedMonitorStatus = null; // nullable type
        }

        public bool TryAddToGlobalPollers()
        {
            AddedToGlobalPollers = PollingEngine.TryAdd(this);
            RegisterProviders();
            return AddedToGlobalPollers;
        }

        public virtual async Task PollAsync(bool force = false)
        {
            using (MiniProfiler.Current.Step("Poll - " + UniqueKey))
            {
                //非强制，则判断是否真需要轮询
                if (!force && !NeedsPoll)
                {
                    return;
                }

                //防止多线程同时运行
                if (Interlocked.CompareExchange(ref _isPolling, 1, 0) != 0)
                {
                    //轮询中
                    return;
                }

                PollStatus = "轮询已启动";
                CurrentPollDuration = Stopwatch.StartNew();
                try
                {
                    PollStatus = "轮询内部已启动";
                    if (Polling != null)
                    {
                        var ps = new PollStartArgs();
                        Polling(this, ps);
                        if (ps.AbortPoll) return;
                    }

                    PollStatus = "目标轮询器开始队列";
                    var tasks = new List<Task>();
                    foreach (var p in DataPollers)
                    {
                        //强制或需要轮询
                        if (force || p.ShouldPoll)
                        {
                            tasks.Add(p.PollGenericAsync());
                        }
                    }

                    if (tasks.Count == 0)
                    {
                        PollStatus = "目标轮询器（Count is 0, none to run）";
                        return;
                    }

                    PollStatus = "目标轮询器队列结束（Now waiting）";
                    await Task.WhenAll(tasks).ConfigureAwait(false);
                    PollStatus = "目标轮询器运行完成（Awaited）";

                    LastPoll = DateTime.Now;
                    Polled?.Invoke(this, new PollResultArgs());
                    Interlocked.Increment(ref _totalPolls);
                }
                finally
                {
                    Interlocked.Exchange(ref _isPolling, 0);
                    if (CurrentPollDuration != null)
                    {
                        CurrentPollDuration.Stop();
                        LastPollDuration = CurrentPollDuration.Elapsed;
                    }
                    CurrentPollDuration = null;
                }
                PollStatus = "轮询完成（已结束）";
            }
        }

        public Cache GetCache(string property)
        {
            return DataPollers.FirstOrDefault(p => p.ParentMemberName == property);
        }

        public void Dispose()
        {
            PollingEngine.TryRemove(this);
        }

        private void RegisterProviders()
        {
        }
    }
}