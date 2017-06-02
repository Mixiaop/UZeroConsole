using U.Dapper.Mapper;

namespace UZeroConsole.Domain.Mappers
{
    public class RoleMapper : ClassMapper<Role>
    {
        public RoleMapper()
        {
            Table(DbConsts.DbTableName.Roles);
            Map(x => x.Id).Key(KeyType.Identity);

            AutoMap();
        }
    }

    public class RolePermissionMapper : ClassMapper<RolePermission>
    {
        public RolePermissionMapper()
        {
            Table(DbConsts.DbTableName.RolePermissions);
            Map(x => x.Id).Key(KeyType.Identity);
            Map(x => x.Role).Ignore();
            Map(x => x.Permission).Ignore();

            AutoMap();
        }
    }
}
