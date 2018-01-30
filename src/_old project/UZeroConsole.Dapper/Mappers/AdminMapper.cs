using U.Dapper.Mapper;

namespace UZeroConsole.Domain.Mappers
{
    public class AdminMapper : ClassMapper<Admin>
    {
        public AdminMapper()
        {
            Table(DbConsts.DbTableName.Admins);
            Map(x => x.Id).Key(KeyType.Identity);
            Map(x => x.Role).Ignore();

            AutoMap();
        }
    }
}
