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
        private static readonly object _addLock = new object();
        private static readonly object _pollAllLock = new object();
        public static readonly HashSet<PollNode> AllPollNodes = new HashSet<PollNode>();

        private static Thread _globalPollingThread;
        private static volatile bool _shuttingDown;
        private static long _totalPollIntervals;
        internal static long _activePolls;
        private static DateTime? _lastPollAll;
        private static DateTime _startTime;

        static PollingEngine()
        {
            StartPolling();
        }

        public static void StartPolling() {
            //_startTime = DateTime.Now;
            //_globalPollingThread = _globalPollingThread??new Thread(moni)
        }

        /// <summary>
        /// 当前轮询完成后执行停止(soft)
        /// </summary>
        public static void StopPolling() {

        }

        

        public static void PollAllAndForget() {

        }

        public static async Task<bool> PollAsync(string nodeType, string key, Guid? cacheGuid = null) {
            throw new Exception();
        }
        #region Private methods
        #endregion

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

        public class GlobalPollingStatus : IMonitorStatus {
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
        #endregion
    }
}
