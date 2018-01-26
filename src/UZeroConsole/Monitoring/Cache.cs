using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Profiling;
using StackExchange.Profiling.Storage;

namespace UZeroConsole.Monitoring
{
    //public class Cache<T> : Cache
    //{
    //}

    public class LightweightCache<T> : LightweightCache where T : class
    {
        public T Data { get; private set; }
        public DateTime? LastFetch { get; private set; }
        public Exception Error { get; private set; }
        public bool Successful => Error == null;
        public string ErrorMessage => Error?.Message + (Error?.InnerException != null ? "\n" + Error.InnerException.Message : "");

        //public static LightweightCache<T> Get(string key, Func<T> getData, TimeSpan duration, TimeSpan staleDuration)
        //{
        //    using (MiniProfiler.Current.Step("LightweightCache: " + key))
        //    {
        //        // Let GetSet handle the overlap and locking, for now. That way it's store dependent.
        //        //return Current.LocalCache.GetSet<LightweightCache<T>>(key, (old, ctx) =>
        //        //{
        //        //    var tc = new LightweightCache<T>() { Key = key };
        //        //    try
        //        //    {
        //        //        tc.Data = getData();
        //        //    }
        //        //    catch (Exception e)
        //        //    {
        //        //        tc.Error = e;
        //        //        Current.LogException(e);
        //        //    }
        //        //    tc.LastFetch = DateTime.Now;
        //        //    return tc;
        //        //}, duration, staleDuration);

        //        //}
        //    }
        //}

    }
        /// <summary>
        /// 轻量级缓存
        /// </summary>
        public class LightweightCache
        {
            public string Key { get; protected set; }
        }

        public abstract class Cache : IMonitorStatus
        {
            public virtual Type Type => typeof(Cache);
            public Guid UniqueId { get; }
            public TimeSpan CacheDuration { get; }
            public TimeSpan? CacheFailureDuration { get; set; } = TimeSpan.FromSeconds(15);
            public bool AffectsNodeStatus { get; set; }

            public DateTime? NextPoll { get; protected set; }
            public DateTime? LastPoll { get; private set; }
            public DateTime? LastSuccess { get; internal set; }
            public bool LastPollSuccessful { get; internal set; }

            public Exception Error { get; internal set; }
            public string ErrorMessage { get; internal set; }

            public string PollStatus { get; internal set; }

            /// <summary>
            /// 来自监控和调试的信息
            /// </summary>
            public string ParentMemberName { get; }
            public string SourceFilePath { get; }
            public int SourceLineNumber { get; }

            protected Cache(
                TimeSpan cacheDuration,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
            {
                UniqueId = Guid.NewGuid();
                CacheDuration = cacheDuration;
                ParentMemberName = memberName;
                SourceFilePath = sourceFilePath;
                SourceLineNumber = sourceLineNumber;
            }

            internal void SetSuccess()
            {
                LastSuccess = LastPoll = DateTime.Now;
                NextPoll = DateTime.Now.Add(CacheDuration);
                LastPollSuccessful = true;
                ErrorMessage = "";
            }

            internal void SetFail(Exception e, string errorMessage)
            {
                LastPoll = DateTime.Now;
                NextPoll = DateTime.Now.Add(CacheFailureDuration ?? CacheDuration);
                LastPollSuccessful = false;
                Error = e;
                ErrorMessage = errorMessage;
            }


            #region IMonitorStatus
            public MonitorStatus MonitorStatus
            {
                get
                {
                    if (LastPoll == null) return MonitorStatus.Unknown;
                    return LastPollSuccessful ? MonitorStatus.Good : MonitorStatus.Critical;
                }
            }

            public string MonitorStatusReason
            {
                get
                {
                    if (LastPoll == null) return "暂无轮询";

                    return !LastPollSuccessful ? LastPoll?.ToRelativeTime() + " 轮询失败：" + ErrorMessage : string.Empty;
                }
            }
            #endregion
        }
    }
