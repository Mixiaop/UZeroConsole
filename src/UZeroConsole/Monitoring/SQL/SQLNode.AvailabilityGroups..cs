using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using U;

namespace UZeroConsole.Monitoring.SQL
{
    public partial class SQLNode
    {
        private Cache<List<AGInfo>> _availabilityGroups;
        public Cache<List<AGInfo>> AvailabilityGroups =>
            _availabilityGroups ?? (_availabilityGroups = GetSqlCache(nameof(AvailabilityGroups), async conn =>
            {
                PerfCounterRecord getCounter(string cn, string n) => GetPerfCounter("Availability Replica", cn, n);
                var sql = QueryLookup.GetOrAdd(Tuple.Create(nameof(AvailabilityGroups), Version), k =>
                        GetFetchSQL<AGInfo>(k.Item2) + "\n" +
                        GetFetchSQL<AGReplica>(k.Item2) + "\n" +
                        GetFetchSQL<AGDatabaseReplica>(k.Item2) + "\n" +
                        GetFetchSQL<AGListener>(k.Item2) + "\n" +
                        GetFetchSQL<AGLisenerIPAddress>(k.Item2)
                );

                List<AGInfo> ags;
                using (var multi = await conn.QueryMultipleAsync(sql).ConfigureAwait(false))
                {
                    ags = await multi.ReadAsync<AGInfo>().ConfigureAwait(false).AsList().ConfigureAwait(false);
                    var replicas = await multi.ReadAsync<AGReplica>().ConfigureAwait(false).AsList().ConfigureAwait(false);
                    var databases = await multi.ReadAsync<AGDatabaseReplica>().ConfigureAwait(false).AsList().ConfigureAwait(false);
                    var listeners = await multi.ReadAsync<AGListener>().ConfigureAwait(false).AsList().ConfigureAwait(false);
                    var listenerIPs = await multi.ReadAsync<AGLisenerIPAddress>().ConfigureAwait(false).AsList().ConfigureAwait(false);

                    // Databases to replicas...
                    foreach (var r in replicas)
                    {
                        r.Databases = databases.Where(db => db.GroupId == r.GroupId && db.ReplicaId == r.ReplicaId).ToList();

                        var instanceName = r.AvailabilityGroupName + ":" + r.ReplicaServerName;
                        var sc = getCounter("Bytes Sent to Transport/sec", instanceName);
                        if (sc != null)
                        {
                            r.BytesSentPerSecond = sc.CalculatedValue;
                            r.BytesSentTotal = sc.CurrentValue;
                        }
                        var rc = getCounter("Bytes Received from Replica/sec", instanceName);
                        if (rc != null)
                        {
                            r.BytesReceivedPerSecond = rc.CalculatedValue;
                            r.BytesReceivedTotal = rc.CurrentValue;
                        }
                    }

                    // Listners IPs to listeners
                    foreach (var l in listeners)
                    {
                        l.Addresses = listenerIPs.Where(la => la.ListenerId == l.ListenerId).ToList();
                    }

                    // Replicas to availability groups
                    foreach (var ag in ags)
                    {
                        ag.Node = this;
                        ag.ClusterName = Cluster.Name;
                        ag.Replicas = replicas.Where(r => r.GroupId == ag.GroupId).ToList();
                        ag.Listeners = listeners.Where(l => l.GroupId == ag.GroupId).ToList();
                    }
                }
                return ags;
            }));

        #region AGDatabaseReplica
        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/ff877972.aspx
        /// </summary>
        public class AGDatabaseReplica : ISQLVersioned, IMonitorStatus
        {
            public Version MinVersion => SQLServerVersions.SQL2012.RTM;

            public int DatabaseId { get; internal set; }
            public Guid GroupId { get; internal set; }
            public Guid ReplicaId { get; internal set; }
            public Guid GroupDatabaseId { get; internal set; }
            public bool? IsLocal { get; internal set; }
            public SynchronizationStates? SynchronizationState { get; internal set; }
            public bool? IsCommitParticipant { get; internal set; }
            public SynchronizationHealths? SynchronizationHealth { get; internal set; }
            public DatabaseStates? DatabaseState { get; internal set; }
            public bool? IsSuspended { get; internal set; }
            public SuspendReasons? SuspendReason { get; internal set; }
            public decimal? RecoveryLSN { get; internal set; }
            public decimal? TruncationLSN { get; internal set; }
            public decimal? LastSentLSN { get; internal set; }
            public DateTime? LastSentTime { get; internal set; }
            public decimal? LastReceivedLSN { get; internal set; }
            public DateTime? LastReceivedTime { get; internal set; }
            public decimal? LastHardenedLSN { get; internal set; }
            public decimal? LastRedoneLSN { get; internal set; }
            public DateTime? LastRedoneTime { get; internal set; }
            public decimal? LastCommitLSN { get; internal set; }
            public DateTime? LastCommitTime { get; internal set; }
            public decimal? EndOfLogLSN { get; internal set; }
            public long? LogSendQueueSize { get; internal set; }
            public long? LogSendRate { get; internal set; }
            public long? RedoQueueSize { get; internal set; }
            public long? RedoRate { get; internal set; }
            public long? FileStreamSendRate { get; internal set; }
            public long? LowWatermarkForGhosts { get; internal set; }
            public string DatabaseName { get; internal set; }
            public long? LogKBytesUsed { get; internal set; }
            public long? LogKBytesTotal { get; internal set; }

            public DateTime? LogSendETA
            {
                get
                {
                    if (LogSendRate.GetValueOrDefault() <= 0 || LogSendQueueSize.GetValueOrDefault() <= 0) return null;
                    var secs = (double)(LogSendQueueSize / LogSendRate);
                    return DateTime.Now.AddSeconds(secs);
                }
            }

            /// <summary>
            /// Returns the *real* log send rate, if there's nothing to send SQL still reports the last high rate, 
            /// when it's actually sending noting.  This will return null as it should in that case.
            /// </summary>
            public long? LogSendRateReal => LogSendQueueSize > 0 ? LogSendRate : null;

            public double? LogPercentUsed
            {
                get
                {
                    if (LogKBytesUsed.GetValueOrDefault() <= 0 || LogKBytesTotal.GetValueOrDefault() <= 0) return null;
                    return (double)(LogKBytesUsed / LogKBytesTotal);
                }
            }

            public MonitorStatus MonitorStatus
            {
                get
                {
                    switch (SynchronizationHealth)
                    {
                        case SynchronizationHealths.NotHealthy:
                        case SynchronizationHealths.PartiallyHealthy:
                            if (IsSuspended.GetValueOrDefault() && SuspendReason == SuspendReasons.UserAction) return MonitorStatus.Warning;
                            return MonitorStatus.Critical;
                    }
                    return MonitorStatus.Good;
                }
            }

            public string MonitorStatusReason
            {
                get
                {
                    switch (SynchronizationHealth)
                    {
                        case SynchronizationHealths.NotHealthy:
                            return DatabaseName + " - not syncing";
                        case SynchronizationHealths.PartiallyHealthy:
                            if (IsSuspended.GetValueOrDefault() && SuspendReason == SuspendReasons.UserAction) return DatabaseName + " - user suspended replication";
                            return DatabaseName + " - partially syncing";
                    }
                    return null;
                }
            }

            public string DatabaseStateDescription => DatabaseState.HasValue
                ? DatabaseState.Value.ToAlias() + (IsSuspended.GetValueOrDefault() ? " (Suspended)" : "")
                : string.Empty;

            public string SuspendReasonDescription => SuspendReason.HasValue ? "Suspended by " + SuspendReason.Value.ToAlias() : string.Empty;

            public string GetFetchSQL(Version v) => @"
Select dbrs.database_id DatabaseId,
       dbrs.group_id GroupId,
       dbrs.replica_id ReplicaId,
       dbrs.group_database_id GroupDatabaseId,
       dbrs.is_local IsLocal,
       dbrs.synchronization_state SynchronizationState,
       dbrs.is_commit_participant IsCommitParticipant,
       dbrs.synchronization_health SynchronizationHealth,
       dbrs.database_state DatabaseState,
       dbrs.is_suspended IsSuspended,
       dbrs.suspend_reason SuspendReason,
       dbrs.recovery_lsn RecoveryLSN,
       dbrs.truncation_lsn TruncationLSN,
       dbrs.last_sent_lsn LastSentLSN,
       dbrs.last_sent_time LastSentTime,
       dbrs.last_received_lsn LastReceivedLSN,
       dbrs.last_received_time LastReceivedTime,
       dbrs.last_hardened_lsn LastHardenedLSN,
       dbrs.last_redone_lsn LastRedoneLSN,
       dbrs.last_redone_time LastRedoneTime,
       dbrs.last_commit_lsn LastCommitLSN,
       dbrs.last_commit_time LastCommitTime,
       dbrs.end_of_log_lsn EndOfLogLSN,
       dbrs.log_send_queue_size LogSendQueueSize,
       dbrs.log_send_rate LogSendRate,
       dbrs.redo_queue_size RedoQueueSize,
       dbrs.redo_rate RedoRate,
       dbrs.filestream_send_rate FileStreamSendRate,
       dbrs.low_water_mark_for_ghosts LowWatermarkForGhosts,
       DB_NAME(database_id) DatabaseName,
       lfu.cntr_value LogKBytesUsed,
	   lft.cntr_value LogKBytesTotal
  From sys.dm_hadr_database_replica_states dbrs
	   Left Join sys.dm_os_performance_counters lfu 
	     On DB_NAME(database_id) = lfu.instance_name
	     And lfu.counter_name = 'Log File(s) Used Size (KB)'
	     And dbrs.is_local = 1
       Left Join sys.dm_os_performance_counters lft 
	     On lfu.instance_name = lft.instance_name
	     And lft.counter_name = 'Log File(s) Size (KB)'";
        }
        #endregion

        #region AGInfo
        /// <summary>
        /// Contains the core info about an availability group, not including any replica data
        /// sys.availability_groups: http://msdn.microsoft.com/en-us/library/ff878538.aspx
        /// sys.dm_hadr_availability_group_states: http://msdn.microsoft.com/en-us/library/ff878491.aspx
        /// </summary>
        public class AGInfo : ISQLVersioned, IMonitedService
        {
            public Version MinVersion => SQLServerVersions.SQL2012.RTM;

            [IgnoreDataMember]
            public SQLNode Node { get; internal set; }
            /* Availability Group Core */
            public string Name { get; internal set; }
            public string ClusterName { get; internal set; }
            public Guid? GroupId { get; internal set; }
            public string ResourceId { get; internal set; }
            public string ResourceGroupId { get; internal set; }
            public int? FailureConditionLevel { get; internal set; }
            public int? HealthCheckTimeout { get; internal set; }
            public AutomatedBackupPreferences BackupPreference { get; internal set; }
            /* Group States */
            public string PrimaryReplica { get; internal set; }
            public bool IsPrimaryReplica { get; internal set; }
            public RecoveryHealths? PrimaryRecoveryHealth { get; internal set; }
            public RecoveryHealths? SecondaryRecoveryHealth { get; internal set; }
            public SynchronizationHealths? GroupSynchronizationHealth { get; internal set; }

            private bool? _hasDatabases;
            public bool HasDatabases
            {
                get
                {
                    if (!_hasDatabases.HasValue)
                    {
                        _hasDatabases = LocalReplica?.Databases.Count > 0
                                        || RemoteReplicas?.Sum(r => r.Databases?.Count ?? 0) > 0;
                    }
                    return _hasDatabases.Value;
                }
            }

            public List<AGReplica> Replicas { get; internal set; }
            public List<AGListener> Listeners { get; internal set; }

            public AGReplica LocalReplica =>
                Replicas.Find(r => r.IsLocal.GetValueOrDefault());

            public IEnumerable<AGReplica> RemoteReplicas =>
                Replicas.Where(r => !r.IsLocal.GetValueOrDefault());

            public MonitorStatus MonitorStatus => Replicas.GetWorstStatus();

            public string MonitorStatusReason => Replicas.GetReasonSummary();

            public string GetFetchSQL(Version v) => @"
Select ag.name Name,
       c.cluster_name ClusterName,
       ag.group_id GroupId,
       ag.resource_id ResourceId,
       ag.resource_group_id ResourceGroupId,
       ag.failure_condition_level FailureConditionLevel,
       ag.health_check_timeout HealthCheckTimeout,
       ag.automated_backup_preference BackupPreference,
       ags.primary_replica PrimaryReplica,
       Cast(Case When ags.primary_replica = @@ServerName Then 1 Else 0 End as Bit) IsPrimaryReplica,
       ags.primary_recovery_health PrimaryRecoveryHealth,
       ags.secondary_recovery_health SecondaryRecoveryHealth,
       ags.synchronization_health GroupSynchronizationHealth
  From sys.availability_groups ag
       Join sys.dm_hadr_availability_group_states ags on ag.group_id = ags.group_id
       Cross Join sys.dm_hadr_cluster c
";
        }
        #endregion

        #region AGListener
        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/hh231328.aspx
        /// </summary>
        public class AGListener : ISQLVersioned
        {
            public Version MinVersion => SQLServerVersions.SQL2012.RTM;

            public Guid GroupId { get; internal set; }
            public string ListenerId { get; internal set; }
            public string DnsName { get; internal set; }
            public int Port { get; internal set; }
            public bool IsConformant { get; internal set; }
            public string IPConfigurationString { get; internal set; }

            public List<AGLisenerIPAddress> Addresses { get; internal set; }
            public List<AGLisenerIPAddress> LocalAddresses { get; internal set; }

            public string GetFetchSQL(Version v) => @"
Select group_id GroupId,
       listener_id ListenerId,
       dns_name DNSName,
       port Port,
       is_conformant IsConformant,
       ip_configuration_string_from_cluster IPConfigurationString
  From sys.availability_group_listeners;";
        }
        #endregion

        #region AGLisenerIPAddress
        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/hh213575.aspx
        /// </summary>
        public class AGLisenerIPAddress : ISQLVersioned, IMonitorStatus
        {
            public Version MinVersion => SQLServerVersions.SQL2012.RTM;

            public string ListenerId { get; internal set; }
            public string IPAddress { get; internal set; }
            public string IPSubnetMask { get; internal set; }
            public string NetworkSubnetIP { get; internal set; }
            public int NetworkSubnetPrefixLength { get; internal set; }
            public string NetworkSubnetIPMask { get; internal set; }
            public ListenerStates? State { get; internal set; }

            // TODO: IsLocal based on ClusterNetworks where MemberName = Server Name 
            // and ClusterNetwork bits match here ()

            private IPNet _ipNet;
            public IPNet IPNet => _ipNet ?? (_ipNet = IPNet.Parse(IPAddress, NetworkSubnetPrefixLength));

            private IPNet _networkIPNet;
            public IPNet NetworkIPNet => _networkIPNet ?? (_networkIPNet = IPNet.Parse(NetworkSubnetIP, NetworkSubnetPrefixLength));

            public MonitorStatus MonitorStatus
            {
                get
                {
                    switch (State)
                    {
                        case ListenerStates.Online:
                            return MonitorStatus.Good;
                        case ListenerStates.OnlinePending:
                            return MonitorStatus.Warning;
                        case ListenerStates.Failed:
                            return MonitorStatus.Critical;
                        //case ListenerStates.Offline:
                        default:
                            return MonitorStatus.Unknown;
                    }
                }
            }

            public string MonitorStatusReason => State.ToString();

            public string GetFetchSQL(Version v) => @"
Select listener_id ListenerId,
       ip_address IPAddress,
       ip_subnet_mask IPSubnetMask,
       network_subnet_ip NetworkSubnetIP,
       network_subnet_prefix_length NetworkSubnetPrefixLength,
       network_subnet_ipv4_mask NetworkSubnetIPMask,
       state State
  From sys.availability_group_listener_ip_addresses;";
        }
        #endregion

        #region AGReplica
        /// <summary>
        /// Contains the replication info about this availability group known to this node - will only be complete on the primary
        /// sys.availability_replicas: http://technet.microsoft.com/en-us/library/ff877883.aspx
        /// sys.dm_hadr_availability_replica_states: http://msdn.microsoft.com/en-us/library/ff878537.aspx
        /// sys.dm_hadr_availability_replica_cluster_states: http://msdn.microsoft.com/en-us/library/hh403396.aspx
        /// </summary>
        public class AGReplica : ISQLVersioned, IMonitorStatus
        {
            public Version MinVersion => SQLServerVersions.SQL2012.RTM;

            public string AvailabilityGroupName { get; internal set; }
            public Guid? GroupId { get; internal set; }
            /* Replicas */
            public Guid? ReplicaId { get; internal set; }
            public int? ReplicaMetadataId { get; internal set; }
            public string ReplicaServerName { get; internal set; }
            public string EndPointUrl { get; internal set; }
            public AvailabilityModes? AvailabilityMode { get; internal set; }
            public FailoverModes FailoverMode { get; internal set; }
            public int? SessionTimeout { get; internal set; }
            public PriRoleAllowConnections? PrimaryRoleAllowConnections { get; internal set; }
            public SecRoleAllowConnections? SecondaryRoleAllowConnections { get; internal set; }
            public DateTime? CreationDate { get; internal set; }
            public DateTime? ModifiedDate { get; internal set; }
            public int? BackupPriority { get; internal set; }
            public string ReadOnlyRoutingUrl { get; internal set; }
            /* Replica State */
            public bool? IsLocal { get; internal set; }
            public ReplicaRoles? Role { get; internal set; }
            public OperationStates? OperationalState { get; internal set; }
            public ConnectedStates? ConnectedState { get; internal set; }
            public RecoveryHealths? RecoveryHealth { get; internal set; }
            public SynchronizationHealths? SynchronizationHealth { get; internal set; }
            public int? LastConnectErrorNumber { get; internal set; }
            public string LastConnectErrorDescription { get; internal set; }
            public DateTime? LastConnectErrorTimeStamp { get; internal set; }
            /* Replica Cluster State */
            public JoinStates JoinState { get; internal set; }
            /* Replication Info */
            public int DBCount => Databases?.Count ?? 0;
            public long TotalLogSendQueueSize => Databases?.Sum(db => db.LogSendQueueSize) ?? 0;
            public long TotalLogSendRate => Databases?.Sum(db => db.LogSendRate) ?? 0;
            public long TotalRedoQueueSize => Databases?.Sum(db => db.RedoQueueSize) ?? 0;
            public long TotalRedoRate => Databases?.Sum(db => db.RedoRate) ?? 0;
            public long TotalFilestreamRate => Databases?.Sum(db => db.FileStreamSendRate) ?? 0;
            public decimal BytesSentPerSecond { get; internal set; }
            public long BytesSentTotal { get; internal set; }
            public decimal BytesReceivedPerSecond { get; internal set; }
            public long BytesReceivedTotal { get; internal set; }

            [IgnoreDataMember]
            public SQLNode ReplicaNode { get; internal set; }
            public List<AGDatabaseReplica> Databases { get; internal set; }

            public MonitorStatus MonitorStatus
            {
                get
                {
                    // Don't alert on empty AGs
                    if (Databases.Count == 0)
                    {
                        return MonitorStatus.Good;
                    }
                    if (SynchronizationHealth.HasValue)
                    {
                        switch (SynchronizationHealth.Value)
                        {
                            case SynchronizationHealths.NotHealthy:
                                return MonitorStatus.Critical;
                            case SynchronizationHealths.PartiallyHealthy:
                                return MonitorStatus.Warning;
                            //case SynchronizationHealths.Healthy:
                            default:
                                return MonitorStatus.Good;
                        }
                    }
                    return Databases.GetWorstStatus();
                }
            }

            public string MonitorStatusReason
            {
                get
                {
                    if (Databases.Count > 0 && SynchronizationHealth.HasValue)
                    {
                        if (SynchronizationHealth == SynchronizationHealths.Healthy)
                            return null;
                        return "Sync health: " + SynchronizationHealth.Value.ToAlias();
                    }
                    return Databases.GetReasonSummary();
                }
            }

            // Why? Because MS doesn't consider DMV perf important, and it's 3-4x faster to temp table 
            // the results then join when many DBs are in an availability group
            public string GetFetchSQL(Version v) => @"
Select * Into #ar From sys.availability_replicas;
Select * Into #ars From sys.dm_hadr_availability_replica_states;
Select * Into #arcs From sys.dm_hadr_availability_replica_cluster_states;
 
Select ag.name AvailabilityGroupName,
       ag.group_id GroupId,
       ar.replica_id ReplicaId,
       ar.replica_metadata_id ReplicaMetadataId,
       ar.replica_server_name ReplicaServerName,
       ar.endpoint_url EndPointUrl,
       ar.availability_mode AvailabilityMode,
       ar.failover_mode FailoverMode,
       ar.session_timeout SessionTimeout,
       ar.primary_role_allow_connections PrimaryRoleAllowConnections,
       ar.secondary_role_allow_connections SecondaryRoleAllowConnections,
       ar.create_date CreationDate,
       ar.modify_date ModifiedDate,
       ar.backup_priority BackupPriority,
       ar.read_only_routing_url ReadOnlyRoutingUrl,
       ars.is_local IsLocal,
       ars.role Role,
       ars.operational_state OperationalState,
       ars.connected_state ConnectedState,
       ars.recovery_health RecoveryHealth,
       ars.synchronization_health SynchronizationHealth,
       ars.last_connect_error_number LastConnectErrorNumber,
       ars.last_connect_error_description LastConnectErrorDescription,
       ars.last_connect_error_timestamp LastConnectErrorTimestamp,
       arcs.join_state JoinState
  From sys.availability_groups ag
       Join #ar ar On ar.group_id = ag.group_id
       Join #ars ars On ar.group_id = ars.group_id And ar.replica_id = ars.replica_id
       Join #arcs arcs On ar.group_id = arcs.group_id And ar.replica_id = arcs.replica_id
 
Drop Table #ar;
Drop Table #ars;
Drop Table #arcs;
";
        }
        #endregion
    }
}
