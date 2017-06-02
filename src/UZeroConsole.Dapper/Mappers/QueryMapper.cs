
namespace UZeroConsole.Domain.Mappers
{
    public class QueryMapper
    {
        public static RolePermissionMapper Map_Role_Permission() {
            var rolePermissionMapper = new RolePermissionMapper();
            var permissionMapper = new PermissionMapper();

            rolePermissionMapper.SetMultiQueryIgnoreColumns("Role,Permission", "Id");
            rolePermissionMapper.MapLeftJoin(x => x.Permission, "PermissionId", permissionMapper, "Id");

            return rolePermissionMapper;
        }
    }
}
