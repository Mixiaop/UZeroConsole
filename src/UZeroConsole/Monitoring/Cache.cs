﻿using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Profiling;
using StackExchange.Profiling.Storage;

namespace UZeroConsole.Monitoring
{
    public class Cache<T> : Cache where T : class
    {
        /// <summary>
        /// Returns if this cache has data - THIS WILL NOT TRIGGER A FETCH
        /// </summary>
        public override bool ContainsData => _hasData == 1 && Data != null;
        private int _hasData;
        internal override object InnerCache => DataTask;
        public override Type Type => typeof(T);
        private readonly SemaphoreSlim _pollSemaphoreSlim = new SemaphoreSlim(1);

        public override string InventoryDescription
        {
            get
            {
                var tmp = Data;
                return tmp == null ? null : ((tmp as IList)?.Count + "项" ?? "1项");
            }
        }

        private readonly Func<Task<T>> _updateFunc;
        private Task<T> DataTask { get; set; }
        public T Data { get; private set; }

        // TODO: Find name that doesn't suck, has to override so...
        public override Task PollGenericAsync(bool force = false) => PollAsync(force);

        // This makes more semantic sense...
        public Task<T> GetData() => PollAsync();

        public Task<T> PollAsync(bool force = false)
        {
            // First call polls data.
            if ((_hasData == 0 && Interlocked.CompareExchange(ref _hasData, 1, 0) == 0) || force)
            {
                DataTask = UpdateAsync(force);
            }
            // Force polls and replaces data when done.
            else if (IsStale)
            {
                return UpdateAsync(false).ContinueWith(_ =>
                {
                    DataTask = _;
                    return _.GetAwaiter().GetResult();
                },
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
            }
            return DataTask;
        }

        private async Task<T> UpdateAsync(bool force)
        {
            PollStatus = "UpdateAsync";
            if (!force && !IsStale) return Data;

            Interlocked.Increment(ref PollingEngine._activePolls);
            PollStatus = "Awaiting Semaphore";
            await _pollSemaphoreSlim.WaitAsync().ConfigureAwait(false);
            bool errored = false;
            try
            {
                if (!force && !IsStale) return Data;
                if (_isPolling) return Data;
                CurrentPollDuration = Stopwatch.StartNew();
                _isPolling = true;
                PollStatus = "UpdateCache";
                await _updateFunc().ConfigureAwait(false);
                PollStatus = "UpdateCache Complete";
                Interlocked.Increment(ref _pollsTotal);
                if (DataTask != null)
                    Interlocked.Increment(ref _pollsSuccessful);
            }
            catch (Exception e)
            {
                var errorMessage = e.Message;
                if (e.InnerException != null) errorMessage += "\n" + e.InnerException.Message;
                SetFail(e, errorMessage);
                errored = true;
            }
            finally
            {
                if (CurrentPollDuration != null)
                {
                    CurrentPollDuration.Stop();
                    LastPollDuration = CurrentPollDuration.Elapsed;
                }
                CurrentPollDuration = null;
                _isPolling = false;
                PollStatus = errored ? "Failed" : "Completed";
                _pollSemaphoreSlim.Release();
                Interlocked.Decrement(ref PollingEngine._activePolls);
            }
            return Data;
        }

        private string MiniProfilerDescription { get; }

        private static readonly MiniProfilerOptions _profilerOptions = new MiniProfilerOptions
        {
            Storage = new NullStorage(),
            ProfilerProvider = new DefaultProfilerProvider()
        };

        /// <summary>
        /// Creates a cache poller
        /// </summary>
        /// <typeparam name="T">Type of item in the cache</typeparam>
        /// <param name="owner">The PollNode owner of this Cache</param>
        /// <param name="description">Description of the operation, used purely for profiling</param>
        /// <param name="cacheDuration">The length of time to cache data for</param>
        /// <param name="getData">The operation used to actually get data, e.g. <code>using (var conn = GetConnectionAsync()) { return getFromConnection(conn); }</code></param>
        /// <param name="timeoutMs">The timeout in milliseconds for this poll to complete before aborting.</param>
        /// <param name="logExceptions">Whether to log any exceptions to the log</param>
        /// <param name="addExceptionData">Optionally add exception data, e.g. <code>e => e.AddLoggedData("Server", Name)</code></param>
        /// <param name="afterPoll">An optional action to run after polling has completed successfully</param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        /// <returns>A cache update action, used when creating a <see cref="Cache"/>.</returns>
        public Cache(PollNode owner,
            string description,
            TimeSpan cacheDuration,
            Func<Task<T>> getData,
            int? timeoutMs = null,
            bool? logExceptions = null,
            Action<Exception> addExceptionData = null,
            Action<Cache<T>> afterPoll = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
            : base(cacheDuration, memberName, sourceFilePath, sourceLineNumber)
        {
            MiniProfilerDescription = "Poll: " + description; // concatenate once
            logExceptions = logExceptions ?? LogExceptions;

            _updateFunc = async () =>
            {
                var success = true;
                PollStatus = "UpdateCacheItem";
                if (EnableProfiling)
                {
                    Profiler = _profilerOptions.StartProfiler(MiniProfilerDescription);
                    Profiler.Id = UniqueId;
                }
                using (MiniProfiler.Current.Step(description))
                {
                    try
                    {
                        PollStatus = "Fetching";
                        using (MiniProfiler.Current.Step("Data Fetch"))
                        {
                            var task = getData();
                            if (timeoutMs.HasValue)
                            {
                                if (await Task.WhenAny(task, Task.Delay(timeoutMs.Value)).ConfigureAwait(false) == task)
                                {
                                    // Re-await for throws.
                                    Data = await task;
                                }
                                else
                                {
                                    // This means the .WhenAny returned the timeout first...boom.
                                    throw new TimeoutException($"Fetch timed out after {timeoutMs} ms.");
                                }
                            }
                            else
                            {
                                Data = await task;
                            }
                        }
                        PollStatus = "Fetch Complete";
                        SetSuccess();
                        afterPoll?.Invoke(this);
                    }
                    catch (Exception e)
                    {
                        success = false;
                        if (logExceptions.Value)
                        {
                            addExceptionData?.Invoke(e);
                            Current.LogException(e);
                        }
                        var errorMessage = StringBuilderCache.Get()
                            .Append("Unable to fetch from ")
                            .Append(owner.NodeType)
                            .Append(": ")
                            .Append(e.Message);
#if DEBUG
                        errorMessage.Append(" @ ").Append(e.StackTrace);
#endif
                        if (e.InnerException != null) errorMessage.AppendLine().Append(e.InnerException.Message);
                        PollStatus = "Fetch Failed";
                        SetFail(e, errorMessage.ToStringRecycle());
                    }
                    owner.PollComplete(this, success);
                }
                if (EnableProfiling)
                {
                    Profiler.Stop();
                }
                PollStatus = "UpdateCacheItem Complete";
                return Data;
            };
        }
    }

    public class LightweightCache<T> : LightweightCache where T : class
    {
        public T Data { get; private set; }
        public DateTime? LastFetch { get; private set; }
        public Exception Error { get; private set; }
        public bool Successful => Error == null;
        public string ErrorMessage => Error?.Message + (Error?.InnerException != null ? "\n" + Error.InnerException.Message : "");

        public static LightweightCache<T> Get(string key, Func<T> getData, TimeSpan duration, TimeSpan staleDuration)
        {
            using (MiniProfiler.Current.Step("LightweightCache: " + key))
            {
                return Current.LocalCache.GetSet<LightweightCache<T>>(key, (old, ctx) =>
                {
                    var tc = new LightweightCache<T>() { Key = key };
                    try
                    {
                        tc.Data = getData();
                    }
                    catch (Exception e)
                    {
                        tc.Error = e;
                        Current.LogException(e);
                    }
                    tc.LastFetch = DateTime.Now;
                    return tc;
                }, duration, staleDuration);

            }
        }
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
        #region Properties
        public virtual Type Type => typeof(Cache);
        public Guid UniqueId { get; }
        public TimeSpan CacheDuration { get; }
        public TimeSpan? CacheFailureDuration { get; set; } = TimeSpan.FromSeconds(15);
        public bool AffectsNodeStatus { get; set; }

        public bool ShouldPoll => IsStale && !_isPolling;

        protected volatile bool _isPolling;
        public bool IsPolling => _isPolling;
        public bool IsStale => (NextPoll ?? DateTime.MinValue) < DateTime.Now;

        protected long _pollsTotal, _pollsSuccessful;
        public long PollsTotal => _pollsTotal;
        public long PollsSuccessful => _pollsSuccessful;

        public Stopwatch CurrentPollDuration { get; protected set; }
        public DateTime? NextPoll { get; protected set; }
        public DateTime? LastPoll { get; internal set; }
        public TimeSpan? LastPollDuration { get; internal set; }
        public DateTime? LastSuccess { get; internal set; }
        public bool LastPollSuccessful { get; internal set; }

        public virtual bool ContainsData => false;
        internal virtual object InnerCache => null;
        public virtual string InventoryDescription => null;

        public Exception Error { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public string PollStatus { get; internal set; }
        public static bool EnableProfiling { get; set; }
        public static bool LogExceptions { get; set; }

        /// <summary>
        /// 来自监控和调试的信息
        /// </summary>
        public string ParentMemberName { get; }
        public string SourceFilePath { get; }
        public int SourceLineNumber { get; }

        public MiniProfiler Profiler { get; protected set; }
        #endregion

        public const string TimedCacheKey = "TimedCache";
        public abstract Task PollGenericAsync(bool force = false);

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

        public static LightweightCache<T> GetTimedCache<T>(string key, Func<T> getData, TimeSpan duration, TimeSpan staleDuration) where T : class
            => LightweightCache<T>.Get(key, getData, duration, staleDuration);

        public static void Purge(string key) => Current.LocalCache.Remove(key);

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
