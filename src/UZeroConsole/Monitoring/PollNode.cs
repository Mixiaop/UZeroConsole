using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZeroConsole.Monitoring
{
    public abstract class PollNode : IDisposable //: IMonitorStatus, IDisposable, IEquatable<PollNode>
    {
        #region Properties
        private int _totalPolls;
        private int _totalCacheSuccesses;
        private int _isPolling;

        protected int PollFailsInaRow;
        protected int FailsBeforeBackoff => 3;
        protected virtual TimeSpan BackoffDuration => TimeSpan.FromSeconds(30);

        public string UniqueKey { get; }
        public DateTime? LastPoll { get; protected set; }
        public TimeSpan LastPollDuration { get; protected set; }
        public bool IsPolling => _isPolling > 0;
        public string PollStatus { get; protected set; } = "Not Started";
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
                if (PollFailsInaRow >= FailsBeforeBackoff && DateTime.UtcNow < LastPoll.GetValueOrDefault() + BackoffDuration)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// 节点最小的轮询间隔（秒）
        /// </summary>
        public abstract int MinSecondsBetweenPolls { get; }
        #endregion

        protected PollNode(string uniqueKey)
        {
            UniqueKey = uniqueKey;
        }

        public virtual async Task PollAsync(bool force = false)
        {
        }

        public void Dispose()
        {
        }
    }
}