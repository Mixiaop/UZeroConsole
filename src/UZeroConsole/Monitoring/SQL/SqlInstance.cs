using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UZeroConsole.Configuration.Monitoring;
using UZeroConsole.Helpers;

namespace UZeroConsole.Monitoring.SQL
{
    public partial class SQLInstance : PollNode, ISearchableNode
    {
        #region Properties & Ctor
        private TimeSpan? _refreshInterval;

        protected string ConnectionString { get; set; }
        protected SQLSettings.Instance Settings { get; }
        protected static readonly ConcurrentDictionary<Tuple<string, Version>, string> QueryLookup =
            new ConcurrentDictionary<Tuple<string, Version>, string>();

        public string Name => Settings.Name;
        public string ObjectName { get; internal set; }
        public string CategoryName => "SQL";
        public virtual string Description => Settings.Description;
        public TimeSpan RefreshInterval => _refreshInterval ?? (_refreshInterval = (Settings.RefreshIntervalSeconds ?? Current.MonitoringSettings.SQL.RefreshIntervalSeconds).Seconds()).Value;

        public Version Version { get; internal set; } = new Version(); // default to 0.0


        public SQLInstance(SQLSettings.Instance settings) : base(settings.Name)
        {
            Settings = settings;
            ConnectionString = settings.ConnectionString.IsNullOrEmpty() ? Current.MonitoringSettings.SQL.DefaultConnectionString.Replace("$ServerName$", settings.Name) : settings.ConnectionString;
            //性能计数
            var csb = new SqlConnectionStringBuilder(ConnectionString);
            var parts = csb.DataSource?.Split(StringSplits.BackSlash);
            if (Settings.ObjectName.IsNotNullOrEmpty())
            {
                ObjectName = settings.ObjectName;
            }
            else
            {
                ObjectName = parts?.Length == 2 ? "MSSQL$" + parts[1].ToUpper() : "SQLServer";
            }
        }
        #endregion

        #region PollNode override
        protected override IEnumerable<MonitorStatus> GetMonitorStatus()
        {
            if (!HasPolled)
                yield return MonitorStatus.Unknown;
            if (HasPolled && !HasPolledCacheSuccessfully)
                yield return MonitorStatus.Critical;
            if (Databases.Data != null)
                yield return Databases.Data.GetWorstStatus();
        }

        protected override string GetMonitorStatusReason()
        {
            return Databases.Data?.GetReasonSummary();
        }

        public override string NodeType => "SQL";
        public override int MinSecondsBetweenPolls => 2;
        public override IEnumerable<Cache> DataPollers
        {
            get
            {
                yield return ServerProperties;
                if (Supports<SQLServiceInfo>())
                    yield return Services;
                if (Supports<Database>())
                    yield return Databases;
                if (Supports<ResourceEvent>())
                    yield return ResourceHistory;
                if (Supports<SQLMemoryClerkSummaryInfo>())
                    yield return MemoryClerkSummary;
                if (Supports<SQLConnectionInfo>())
                    yield return Connections;
                if (Supports<SQLConnectionSummaryInfo>())
                    yield return ConnectionsSummary;
                if (Supports<PerfCounterRecord>())
                    yield return PerfCounters;
                if (Supports<VolumeInfo>())
                    yield return Volumes;
            }
        }
        #endregion

        /// <summary>
        /// 获取当前服务的连接（需要释放它）
        /// </summary>
        /// <param name="timeoutMs">打开连接时等待的最大毫秒数</param>
        protected Task<DbConnection> GetConnectionAsync(int timeoutMs = 5000) => Connection.GetOpenAsync(ConnectionString, connectionTimeoutMs: timeoutMs);

        /// <summary>
        /// 获取当前服务的连接（需要释放它）异步
        /// TODO: Mvc Core 移除了异步视图
        /// </summary>
        /// <param name="timeoutMs">打开连接时等待的最大毫秒数</param>
        protected DbConnection GetConnection(int timeoutMs = 5000) => Connection.GetOpen(ConnectionString, connectionTimeoutMs: timeoutMs);

        public bool Supports<T>() where T : ISQLVersioned, new() => Version >= Singleton<T>.Instance.MinVersion;

        public string GetFetchSQL<T>() where T : ISQLVersioned, new() => GetFetchSQL<T>(Version);
        public string GetFetchSQL<T>(Version v) where T : ISQLVersioned, new() => Singleton<T>.Instance.GetFetchSQL(v);

        public override string ToString() => Name;

        #region Cache
        public Cache<List<T>> SqlCacheList<T>(
            TimeSpan cacheDuration,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
            where T : class, ISQLVersioned, new()
        {
            return GetSqlCache(memberName,
                conn => conn.QueryAsync<T>(GetFetchSQL<T>()),
                Supports<T>,
                cacheDuration,
                memberName: memberName,
                sourceFilePath: sourceFilePath,
                sourceLineNumber: sourceLineNumber
            );
        }

        public Cache<T> SqlCacheSingle<T>(
            TimeSpan cacheDuration,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
            where T : class, ISQLVersioned, new()
        {
            return GetSqlCache(memberName,
                conn => conn.QueryFirstOrDefaultAsync<T>(GetFetchSQL<T>()),
                Supports<T>,
                cacheDuration,
                logExceptions: true,
                memberName: memberName,
                sourceFilePath: sourceFilePath,
                sourceLineNumber: sourceLineNumber);
        }

        protected Cache<T> GetSqlCache<T>(
            string opName,
            Func<DbConnection, Task<T>> get,
            Func<bool> shouldRun = null,
            TimeSpan? cacheDuration = null,
            bool logExceptions = false,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            ) where T : class, new()
        {
            return new Cache<T>(this, "SQL Fetch: " + Name + ":" + opName,
                cacheDuration ?? RefreshInterval,
                getData: async () =>
                {
                    if (shouldRun != null && !shouldRun()) return new T();
                    using (var conn = await GetConnectionAsync().ConfigureAwait(false))
                    {
                        return await get(conn).ConfigureAwait(false);
                    }
                },
                logExceptions: logExceptions,
                addExceptionData: e => e.AddLoggedData("Server", Name),
                memberName: memberName,
                sourceFilePath: sourceFilePath,
                sourceLineNumber: sourceLineNumber
            );
        }

        public LightweightCache<T> TimedCache<T>(string key, Func<DbConnection, T> get, TimeSpan duration, TimeSpan staleDuration) where T : class
        => Cache.GetTimedCache(GetCacheKey(key),
            () =>
            {
                using (var conn = GetConnection())
                {
                    return get(conn);
                }
            }, duration, staleDuration);
        private string GetCacheKey(string itemName) { return $"SQL-Instance-{Name}-{itemName}"; }
        #endregion
    }
}
