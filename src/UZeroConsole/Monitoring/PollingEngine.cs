using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace UZeroConsole.Monitoring
{
    public static class PollingEngine
    {
        #region Properties
        private static readonly object _addLock = new object();
        private static readonly object _pollAllLock = new object();

        private static Thread _globalPollingThread;
        private static volatile bool _shuttingDown;
        private static long _totalPollIntervals;
        private static DateTime? _lastPollAll;
        private static DateTime _startTime;

        internal static long _activePolls;
        public static readonly HashSet<PollNode> AllPollNodes = new HashSet<PollNode>();
        #endregion

        static PollingEngine()
        {
            StartPolling();
        }

        public static bool TryAdd(PollNode node)
        {
            lock (_addLock)
            {
                return AllPollNodes.Add(node);
            }
        }

        public static bool TryRemove(PollNode node)
        {
            if (node == null || !node.AddedToGlobalPollers) return false;
            lock (_addLock)
            {
                return AllPollNodes.Remove(node);
            }
        }

        /// <summary>
        /// 创建全局的轮询线程并启动
        /// </summary>
        public static void StartPolling()
        {
            if (Current.ConsoleSettings.UseMonitoring)
            {
                _startTime = DateTime.Now;
                _globalPollingThread = _globalPollingThread ?? new Thread(MonitorPollingLoop)
                {
                    Name = "UZeroConsole.Monitoring.GlobalPolling",
                    Priority = ThreadPriority.Lowest,
                    IsBackground = true
                };

                if (!_globalPollingThread.IsAlive)
                {
                    _globalPollingThread.Start();
                }
            }
        }

        public static void StopPolling()
        {
            if (Current.ConsoleSettings.UseMonitoring)
            {
                _shuttingDown = true;
            }
        }

        public static void PollAllAndForget()
        {
            if (!Monitor.TryEnter(_pollAllLock, 500)) return;
            Interlocked.Increment(ref _totalPollIntervals);
            try
            {
                foreach (var n in AllPollNodes)
                {
                    if (n.IsPolling || !n.NeedsPoll)
                    {
                        continue;
                    }
                    //后台执行节点任务
                    HostingEnvironment.QueueBackgroundWorkItem(ct => n.PollAsync());
                }
            }
            catch (Exception ex)
            {
                Current.LogException(ex);
            }
            finally
            {
                Monitor.Exit(_pollAllLock);
            }
            _lastPollAll = DateTime.Now;
        }

        public static async Task<bool> PollAsync(string nodeType, string key, Guid? cacheGuid = null)
        {
            if (nodeType == Cache.TimedCacheKey)
            {
                Cache.Purge(key);
                return true;
            }

            var node = AllPollNodes.FirstOrDefault(p => p.NodeType == nodeType && p.UniqueKey == key);
            if (node == null) return false;

            if (cacheGuid.HasValue)
            {
                var cache = node.DataPollers.FirstOrDefault(p => p.UniqueId == cacheGuid);
                if (cache != null)
                {
                    await cache.PollGenericAsync(true).ConfigureAwait(false);
                }
                return cache?.LastPollSuccessful ?? false;
            }
            // Polling an entire server
            await node.PollAsync(true).ConfigureAwait(false);
            return true;
        }

        public static List<PollNode> GetNodes(string type)
        {
            return AllPollNodes.Where(pn => string.Equals(pn.NodeType, type, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public static PollNode GetNode(string type, string key)
        {
            return AllPollNodes.FirstOrDefault(pn => string.Equals(pn.NodeType, type, StringComparison.InvariantCultureIgnoreCase) && pn.UniqueKey == key);
        }

        public static Cache GetCache(Guid id)
        {
            foreach (var pn in AllPollNodes)
            {
                foreach (var c in pn.DataPollers)
                {
                    if (c.UniqueId == id) return c;
                }
            }
            return null;
        }

        #region Global polling status
        public static GlobalPollingStatus GetPollingStatus()
        {
            return new GlobalPollingStatus
            {
                MonitorStatus = _globalPollingThread.IsAlive ? (AllPollNodes.Count > 0 ? MonitorStatus.Good : MonitorStatus.Unknown) : MonitorStatus.Critical,
                MonitorStatusReason = _globalPollingThread.IsAlive ? (AllPollNodes.Count > 0 ? null : "无轮询节点") : "全局轮询线程已挂",
                StartTime = _startTime,
                LastPollAll = _lastPollAll,
                IsAlive = _globalPollingThread.IsAlive,
                TotalPollIntervals = _totalPollIntervals,
                ActivePolls = _activePolls,
                NodeCount = AllPollNodes.Count,
                TotalPollers = AllPollNodes.Sum(n => n.DataPollers.Count()),
                NodeBreakdown = AllPollNodes.GroupBy(n => n.GetType()).Select(g => Tuple.Create(g.Key, g.Count())).ToList(),
                Nodes = AllPollNodes.ToList()
            };
        }

        public class GlobalPollingStatus : IMonitorStatus
        {
            public MonitorStatus MonitorStatus { get; internal set; }
            public string MonitorStatusReason { get; internal set; }
            public DateTime StartTime { get; internal set; }
            public DateTime? LastPollAll { get; internal set; }
            public bool IsAlive { get; internal set; }
            public long TotalPollIntervals { get; internal set; }
            public long ActivePolls { get; internal set; }
            public int NodeCount { get; internal set; }
            public int TotalPollers { get; internal set; }
            public List<Tuple<Type, int>> NodeBreakdown { get; internal set; }
            public List<PollNode> Nodes { get; internal set; }
        }
        #endregion

        #region ThreadStats
        public static ThreadStats GetThreadStats() => new ThreadStats();

        public class ThreadStats
        {
            private readonly int _minWorkerThreads;
            public int MinWorkerThreads => _minWorkerThreads;

            private readonly int _minIOThreads;
            public int MinIOThreads => _minIOThreads;

            private readonly int _availableWorkerThreads;
            public int AvailableWorkerThreads => _availableWorkerThreads;

            private readonly int _availableIOThreads;
            public int AvailableIOThreads => _availableIOThreads;

            private readonly int _maxIOThreads;
            public int MaxIOThreads => _maxIOThreads;

            private readonly int _maxWorkerThreads;
            public int MaxWorkerThreads => _maxWorkerThreads;

            public int BusyIOThreads => _maxIOThreads - _availableIOThreads;
            public int BusyWorkerThreads => _maxWorkerThreads - _availableWorkerThreads;

            public ThreadStats()
            {
                ThreadPool.GetMinThreads(out _minWorkerThreads, out _minIOThreads);
                ThreadPool.GetAvailableThreads(out _availableWorkerThreads, out _availableIOThreads);
                ThreadPool.GetMaxThreads(out _maxWorkerThreads, out _maxIOThreads);
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// 确保启动
        /// </summary>
        private static void MonitorPollingLoop()
        {
            while (!_shuttingDown)
            {
                try
                {
                    StartPollLoop();
                }
                catch (ThreadAbortException e)
                {
                    if (!_shuttingDown)
                        Current.LogException("全局轮询循环已挂", e);
                }
                catch (Exception ex)
                {
                    Current.LogException(ex);
                }
                try
                {
                    Thread.Sleep(2000);
                }
                catch (ThreadAbortException)
                {
                    // 没事，应用程序已循环
                }
            }
        }

        private static void StartPollLoop()
        {
            while (!_shuttingDown)
            {
                PollAllAndForget();
                Thread.Sleep(1000);
            }
        }
        #endregion
    }
}
