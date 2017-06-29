
namespace UZeroConsole
{
    public class DbConsts
    {
        public const string MultiQueryIgnoreColumns = "Id,IsDeleted,DeletionTime,DeleterUserId,LastModificationTime,LastModifierUserId,CreatorUserId,CreationTime";

        public class DbTableName
        {
            //Console
            public const string Admins = "UZeroConsole_Admins";
            public const string AdminLogs = "UZeroConsole_AdminLogs";
            public const string Roles = "UZeroConsole_Roles";
            public const string Permissions = "UZeroConsole_Permissions";
            public const string RolePermissions = "UZeroConsole_RolePermissions";

            public const string Jobs_RemoteJobs = "UZeroConsole_Jobs_RemoteJobs";

            public const string Logging_LogApps = "UZeroConsole_Logging_LogApps";
            public const string Logging_ExceptionLogs = "UZeroConsole_Logging_ExceptionLogs";
            public const string Logging_ActionLogs = "UZeroConsole_Logging_ActionLogs";
            public const string Logging_ActionModules = "UZeroConsole_Logging_ActionModules";
            public const string Logging_VisitLogs = "UZeroConsole_Logging_VisitLogs";

            public const string Config_ConfigProjects = "UZeroConsole_Config_ConfigProjects";
            public const string Config_ConfigObjects = "UZeroConsole_Config_ConfigObjects";
            public const string Config_ConfigAttrs = "UZeroConsole_Config_ConfigAttrs";
            
        }
    }
}
