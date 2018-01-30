using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Threading;
using System.Threading.Tasks;
using U;
using U.BackgroundJobs;


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

        /// <summary>
        /// 创建全局的轮询线程并启动
        /// </summary>
        public static void StartPolling()
        {
            if (Current.Settings.Console.UseMonitoring)
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
            if (Current.Settings.Console.UseMonitoring)
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
            throw new Exception();
        }

        #region GlobalPollingStatus
        public static GlobalPollingStatus GetPollingStatus()
        {
            return new GlobalPollingStatus
            {
                //MonitorStatus = _globalPollingThread.IsAlive ? (AllPollNodes.Count > 0 ? MonitorStatus.Good : MonitorStatus.Unknown) : MonitorStatus.Critical,
                //MonitorStatusReason = _globalPollingThread.IsAlive ? (AllPollNodes.Count > 0 ? null : "无轮询节点") : "全局轮询线程已挂",
                //StartTime = _startTime,
                //LastPollAll = _lastPollAll,
                //IsAlive = _globalPollingThread.IsAlive,
                //TotalPollIntervals = _totalPollIntervals,
                //ActivePolls = _activePolls,
                //NodeCount = AllPollNodes.Count,
                //TotalPollers = AllPollNodes.Sum(n => n.DataPollers.Count()),
                //NodeBreakdown = AllPollNodes.GroupBy(n => n.GetType()).Select(g => Tuple.Create(g.Key, g.Count())).ToList(),
                //Nodes = AllPollNodes.ToList()
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
                        Current.LogException("Global polling loop shutting down", e);
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
                    // application is cycling, AND THAT'S OKAY
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

        #region ThreadStats
        #endregion
    }
}
