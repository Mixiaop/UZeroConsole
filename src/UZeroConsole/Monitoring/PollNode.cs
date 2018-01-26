using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZeroConsole.Monitoring
{
    public abstract class PollNode : IDisposable //: IMonitorStatus, IDisposable, IEquatable<PollNode>
    {
        private int _totalPolls;
        private int _totalCacheSuccesses;

        //public virtual MonitorStatus MonitorStatus
        //{
        //    get {

        //    }
        //}

        public string UniqueKey { get; }
        protected PollNode(string uniqueKey)
        {
            UniqueKey = uniqueKey;
        }
        public void Dispose()
        {
        }
    }
}