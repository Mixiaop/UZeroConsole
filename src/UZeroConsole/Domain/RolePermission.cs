using U.Domain.Entities;

namespace UZeroConsole.Domain
{
    /// <summary>
    /// 代表一个“角色与权限”的映射
    /// </summary>
    public class RolePermission : Entity
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 权限Id
        /// </summary>
        public int PermissionId { get; set; }

        /// <summary>
        ///角色
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual Permission Permission { get; set; }
    }
}
