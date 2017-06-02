using U.Dapper.Mapper;

namespace UZeroConsole.Domain.Mappers
{
    public class PermissionMapper : ClassMapper<Permission>
    {
        public PermissionMapper()
        {
            Table(DbConsts.DbTableName.Permissions);
            Map(x => x.Id).Key(KeyType.Identity);

            AutoMap();
        }
    }
}
