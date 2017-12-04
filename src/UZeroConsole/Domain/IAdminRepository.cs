using System.Collections.Generic;
using U.Domain.Repositories;

namespace UZeroConsole.Domain
{
    /// <summary>
    /// 后台管理员仓储服务接口
    /// </summary>
    public interface IAdminRepository : IRepository<Admin>
    {
        /// <summary>
        /// 为管理员设置角色，设置时会清除原来的角色
        /// </summary>
        /// <param name="adminId">管理员Id</param>
        /// <param name="roleIds">角色Id列表</param>
        void SetRoles(int adminId, List<int> roleIds);
    }
}
