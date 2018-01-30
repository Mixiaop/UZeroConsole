
namespace UZeroConsole
{
    public class DbConsts
    {
        public const string MultiQueryIgnoreColumns = "Id,IsDeleted,DeletionTime,DeleterUserId,LastModificationTime,LastModifierUserId,CreatorUserId,CreationTime";

        public class DbTableName
        {
            //Console
            public const string Admins = "UZeroConsole_Admins";
            public const string Roles = "UZeroConsole_Roles";
            public const string Permissions = "UZeroConsole_Permissions";
            public const string RolePermissions = "UZeroConsole_RolePermissions";
        }
    }
}
