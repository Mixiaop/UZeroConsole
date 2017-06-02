using System.Collections.Generic;
using U.Application.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services
{
    /// <summary>
    /// 角色权限服务接口
    /// </summary>
    public interface IRoleService : IApplicationService
    {
        #region Role
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="input"></param>
        void Insert(InsertOrUpdateRoleInput input);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="input"></param>
        void Update(InsertOrUpdateRoleInput input);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id">角色Id</param>
        /// <returns></returns>
        RoleDto Get(int id);

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        IList<RoleDto> GetAll();
        #endregion

        #region RolePermission
        /// <summary>
        /// 为角色添一个权限
        /// </summary>
        /// <param name="rolePermission">对象</param>
        void AddPermission(RolePermissionDto rolePermission);

        /// <summary>
        /// 删除对应角色的所有权限
        /// </summary>
        /// <param name="roleId">角色Id</param>
        void DeleteAllPermissions(int roleId);

        /// <summary>
        /// 获取对应角色的所有权限
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        IList<RolePermissionDto> GetPermissions(int roleId);

        /// <summary>
        /// 获取对应角色的所有权限
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        IList<RolePermissionDto> GetPermissions(List<int> roleIds);
        #endregion
    }
}
