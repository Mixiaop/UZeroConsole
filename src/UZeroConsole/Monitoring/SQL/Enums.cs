using System.ComponentModel;
using U.CodeAnnotations;

namespace UZeroConsole.Monitoring.SQL
{
    public enum AutomatedBackupPreferences : byte
    {
        [EnumAlias("Primary")] Primary = 0,
        [EnumAlias("Secondary")] Secondary = 1,
        [EnumAlias("Prefer Secondary")] PreferSecondary = 2,
        [EnumAlias("Any Replica")] AnyReplica = 3
    }

    public enum AvailabilityModes : byte
    {
        [EnumAlias("Asyncrhonous Commit")] AsyncrhonousCommit = 0,
        [EnumAlias("Syncrhonous Commit")] SynchronousCommit = 1
    }

    public enum QuorumTypes : byte
    {
        [EnumAlias("Node Majority")] NodeMajority = 0,
        [EnumAlias("Node and Disk Majority")] NodeAndDiskMajority = 1,
        [EnumAlias("Node and File Share Majority")] NodeAndFileShareMajority = 2,
        [EnumAlias("No Majority")] NoMajority = 3,
        [EnumAlias("Unknown")] Unknown = 4
    }

    public enum QuorumStates : byte
    {
        [EnumAlias("Unknown Quorum State")] Unknown = 0,
        [EnumAlias("Normal")] Normal = 1,
        [EnumAlias("Forced")] Forced = 2
    }

    public enum ClusterMemberStates : byte
    {
        [EnumAlias("Offline")] Offline = 0,
        [EnumAlias("Online")] Online = 1
    }

    public enum ClusterMemberTypes : byte
    {
        [EnumAlias("WSFC Node")] WSFCNode = 0,
        [EnumAlias("Disk Witness")] DiskWitness = 1,
        [EnumAlias("File Share Witness")] FileShareWitness = 2
    }

    public enum ConnectedStates : byte
    {
        [EnumAlias("Disconnected")] Disconnected = 0,
        [EnumAlias("Connected")] Connected = 1
    }

    public enum DatabaseStates : byte
    {
        [EnumAlias("Online")] Online = 0,
        [EnumAlias("Restoring")] Restoring = 1,
        [EnumAlias("Recovering")] Recovering = 2,
        [EnumAlias("Recovery Pending")] RecoveryPending = 3,
        [EnumAlias("Suspect")] Suspect = 4,
        [EnumAlias("Emergency")] Emergency = 5,
        [EnumAlias("Offline")] Offline = 6,
        [EnumAlias("Copying")] Copying = 7
    }

    public enum FailoverModes : byte
    {
        [EnumAlias("Manual")] Manual = 1,
        [EnumAlias("Automatic")] Automatic = 2
    }

    public enum JoinStates : byte
    {
        [EnumAlias("Not Joined")] NotJoined = 0,
        [EnumAlias("Joined (Standalone)")] JoinedStandalone = 1,
        [EnumAlias("Joined (Failover)")] JoinedFailover = 2
    }

    public enum ListenerStates : byte
    {
        [EnumAlias("Offline")] Offline = 0,
        [EnumAlias("Online")] Online = 1,
        [EnumAlias("Online Pending")] OnlinePending = 2,
        [EnumAlias("Failed")] Failed = 3
    }

    public enum OperationStates : byte
    {
        [EnumAlias("Pending Failover")] PendingFailover = 0,
        [EnumAlias("Pending")] Pending = 1,
        [EnumAlias("Online")] Online = 2,
        [EnumAlias("Offline")] Offline = 3,
        [EnumAlias("Failed")] Failed = 4,
        [EnumAlias("Failed (No Quorum)")] FailedNoQuorun = 5
        // null = not local
    }

    public enum PriRoleAllowConnections : byte
    {
        [EnumAlias("All")] All = 2,
        [EnumAlias("Read/Write")] ReadWrite = 3
    }

    public enum RecoveryHealths : byte
    {
        [EnumAlias("In Progress")] InProgress = 0,
        [EnumAlias("Online")] Online = 1
    }

    public enum ReplicaRoles : byte
    {
        [EnumAlias("Resolving")] Resolving = 0,
        [EnumAlias("Primary")] Primary = 1,
        [EnumAlias("Secondary")] Secondary = 2
    }

    public enum SecRoleAllowConnections : byte
    {
        [EnumAlias("No")] No = 0,
        [EnumAlias("Read Only")] ReadOnly = 1,
        [EnumAlias("All")] All = 2
    }

    public enum SuspendReasons : byte
    {
        [EnumAlias("User Action")] UserAction = 0,
        [EnumAlias("Suspend From Partner")] SuspendFromPartner = 1,
        [EnumAlias("Redo")] Redo = 2,
        [EnumAlias("Apply")] Apply = 3,
        [EnumAlias("Capture")] Capture = 4,
        [EnumAlias("Restart")] Restart = 5,
        [EnumAlias("Undo")] Undo = 6,
        [EnumAlias("Revaldiation")] Revaldiation = 7,
        [EnumAlias("Error in the calculation of the secondary replica synchronization point")] ErrorInSecondaryReplicaSyncPoint = 8
    }

    public enum SynchronizationHealths : byte
    {
        [EnumAlias("Not Healthy (None)")] NotHealthy = 0,
        [EnumAlias("Partially Healthy (Some)")] PartiallyHealthy = 1,
        [EnumAlias("Healthy")] Healthy = 2
    }

    public enum SynchronizationStates : byte
    {
        [EnumAlias("Not Synchronizing")] NotSynchronizing = 0,
        [EnumAlias("Synchronizing")] Synchronizing = 1,
        [EnumAlias("Synchronized")] Synchronized = 2,
        [EnumAlias("Reverting")] Reverting = 3,
        [EnumAlias("Initializing")] Initializing = 4
    }

    public enum TCPListenerStates : short
    {
        [EnumAlias("Online")] Online = 0,
        [EnumAlias("Pending Restart")] PendingRestart = 1
    }

    public enum TCPListenerTypes : short
    {
        [EnumAlias("Transact-SQL")] TransactSQL = 0,
        [EnumAlias("Service Broker")] ServiceBroker = 1,
        [EnumAlias("Database Mirroring")] DatabaseMirroring = 2
    }

    public enum CompatabilityLevels : byte
    {
        [EnumAlias("2008 & 2008 R2 (70)")] Level70 = 70,
        [EnumAlias("2008 & 2008 R2 (80)")] Level80 = 80,
        [EnumAlias("2008 - 2012 (90)")] Level90 = 90,
        [EnumAlias("2008 - 2012 (100)")] Level100 = 100,
        [EnumAlias("2012 Only (110)")] Level110 = 110
    }

    public enum RecoveryModels : byte
    {
        [EnumAlias("Full")] Full = 1,
        [EnumAlias("Bulk Logged")] BulkLogged = 2,
        [EnumAlias("Simple")] Simple = 3
    }

    public enum PageVerifyOptions : byte
    {
        [EnumAlias("None")] None = 0,
        [EnumAlias("Torn Page Detection")] TornPageDetection = 1,
        [EnumAlias("Checksum")] Checksum = 2
    }

    public enum LogReuseWaits : byte
    {
        [EnumAlias("None")] Nothing = 0,
        [EnumAlias("Checkpoint")] Checkpoint = 1,
        [EnumAlias("Log Backup")] LogBackup = 2,
        [EnumAlias("Active Backup or Restore")] ActiveBackupOrRestore = 3,
        [EnumAlias("Active Transaction")] ActiveTransaction = 4,
        [EnumAlias("Database Mirroring")] DatabaseMirroring = 5,
        [EnumAlias("replication")] Replication = 6,
        [EnumAlias("Database Snapshot Creation")] DatabaseSnapshotCreation = 7,
        [EnumAlias("Log Scan")] LogScan = 8,
        [EnumAlias("Always On Replication")] AlwaysOnReplicaTransactionLogs = 9,
        [EnumAlias("Internal Use")] Internal10 = 10,
        [EnumAlias("Internal Use")] Internal11 = 11,
        [EnumAlias("Internal Use")] Internal12 = 12,
        [EnumAlias("Internal Use")] OldestPage = 13,
        [EnumAlias("Other (transient)")] Other = 14
    }

    public enum UserAccesses : byte
    {
        [EnumAlias("Multi-User")] MultiUser = 0,
        [EnumAlias("Single User")] SingleUser = 1,
        [EnumAlias("Restricted User")] RestrictedUser = 2
    }

    public enum SnapshotIsolationStates : byte
    {
        [EnumAlias("Off")] Off = 0,
        [EnumAlias("On")] On = 1,
        [EnumAlias("On (Transitioning to Off)")] TransitioningToOff = 2,
        [EnumAlias("Off (Transitioning to On)")] TransitioningToOn = 3
    }

    public enum Containments : byte
    {
        [EnumAlias("Off")] Off = 0,
        [EnumAlias("Partial")] Partial = 1
    }

    public enum FullTextInstallStatus
    {
        [EnumAlias("Not Installed")] NotInstalled = 0,
        [EnumAlias("Installed")] Installed = 1
    }

    public enum HADREnabledStatus
    {
        [EnumAlias("Enabled")] Enabled = 0,
        [EnumAlias("Disabled")] Disabled = 1
    }

    public enum HADRManagerStatus
    {
        [EnumAlias("Not started, pending communication")] NotStarted = 0,
        [EnumAlias("Started and running")] Running = 1,
        [EnumAlias("Not started and failed")] Failed = 2
    }

    public enum MediaDeviceTypes : byte
    {
        [EnumAlias("Disk")] Disk = 2,
        [EnumAlias("Tape")] Tape = 4,
        [EnumAlias("Virtual Device")] VirtualDevice = 7,
        [EnumAlias("Permenant Device")] Permenant = 105
    }

    public enum VirtualMachineTypes
    {
        [EnumAlias("None")] None = 0,
        [EnumAlias("Hypervisor")] Hypervisor = 1,
        [EnumAlias("Other")] Other = 2
    }

    public enum ServiceStartupTypes
    {
        [EnumAlias("Other (0)")] Other0 = 0,
        [EnumAlias("Other (1)")] Other1 = 1,
        [EnumAlias("Automatic")] Automatic = 2,
        [EnumAlias("Manual")] Manual = 3,
        [EnumAlias("Disabled")] Disabled = 4
    }

    public enum ServiceStatuses
    {
        [EnumAlias("Stopped")] Stopped = 1,
        [EnumAlias("Start Pending")] StartPending = 2,
        [EnumAlias("Stop Pending")] StopPending = 3,
        [EnumAlias("Running")] Running = 4,
        [EnumAlias("Continue Pending")] ContinuePending = 5,
        [EnumAlias("Pause Pending")] PausePending = 6,
        [EnumAlias("Paused")] Paused = 7
    }

    public enum JobStatuses
    {
        [EnumAlias("Failed")] Failed = 0,
        [EnumAlias("Succeeded")] Succeeded = 1,
        [EnumAlias("Retry")] Retry = 2,
        [EnumAlias("Canceled")] Canceled = 3
    }

    public enum JobRunSources
    {
        [EnumAlias("Scheduler")] Scheduler = 1,
        [EnumAlias("Alerter")] Alerter = 2,
        [EnumAlias("Boot")] Boot = 3,
        [EnumAlias("User")] User = 4,
        [EnumAlias("On Idle Schedule")] OnIdleSchedule = 6
    }

    public enum TableTypes
    {
        [EnumAlias("Heap")] Heap = 0,
        [EnumAlias("Clustered")] Clustered = 1
    }

    public enum TransactionIsolationLevel : short
    {
        [EnumAlias("Unspecified")] Unspecified = 0,
        [EnumAlias("Uncommited")] ReadUncomitted = 1,
        [EnumAlias("Commited")] ReadCommitted = 2,
        [EnumAlias("Repeatable")] Repeatable = 3,
        [EnumAlias("Serializable")] Serializable = 4,
        [EnumAlias("Snapshot")] Snapshot = 5
    }

    public enum DatabaseFileTypes : byte
    {
        [EnumAlias("Rows")] Rows = 0,
        [EnumAlias("Log")] Log = 1,
        [EnumAlias("Reserved (2)")] Reserved2 = 2,
        [EnumAlias("Reserved (3)")] Reserved3 = 3,
        [EnumAlias("Full-text")] FullText = 4
    }

    public enum DatabaseFileStates : byte
    {
        [EnumAlias("Online")] Online = 0,
        [EnumAlias("Restoring")] Restoring = 1,
        [EnumAlias("Recovering")] Recovering = 2,
        [EnumAlias("Recovery Pending")] RecoveryPending = 3,
        [EnumAlias("Suspect")] Suspect = 4,
        [EnumAlias("Reserved (5)")] Reserved5 = 5,
        [EnumAlias("Offline")] Offline = 6,
        [EnumAlias("Defunct")] Defunct = 7
    }

    public enum IndexType : byte
    {
        [EnumAlias("Heap")] Heap = 0,
        [EnumAlias("Clustered")] Clustered = 1,
        [EnumAlias("Nonclustered")] Nonclustered = 2,
        [EnumAlias("XML")] XML = 3,
        [EnumAlias("Spatial")] Spatial = 4,
        [EnumAlias("Clustered Columnstore")] ClusteredColumnstore = 5,
        [EnumAlias("Nonclustered Columnstore")] NonclusteredColumnstore = 6,
        [EnumAlias("Nonclustered Hash")] NonclusteredHash = 7
    }

    public enum PartitionDataCompression : byte
    {
        [EnumAlias("None")] None = 0,
        [EnumAlias("Row")] Row = 1,
        [EnumAlias("Page")] Page = 2,
        [EnumAlias("Columnstore")] Columnstore = 3,
        [EnumAlias("Columnstore (Archive)")] ColumnstoreArchive = 4
    }
}
