using System.Collections.Generic;
using System.Linq;
using U.AutoMapper;
using U.UI;
using U.Domain.Entities;
using UZeroConsole.Domain;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services
{
    public class RoleService : IRoleService
    {
        #region Fields & Ctor
        private readonly IRoleRepository _roleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        public RoleService(IRoleRepository roleRepository, IRolePermissionRepository rolePermissionRepository)
        {
            _roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
        }
        #endregion

        #region Role
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="input"></param>
        public void Insert(InsertOrUpdateRoleInput input)
        {
            if (string.IsNullOrEmpty(input.Name)) { throw new UserFriendlyException("角色名称不能为空"); }
            var role = new Role();
            role.Name = input.Name;
            role.Remark = input.Remark;
            _roleRepository.Insert(role);

        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="input"></param>
        public void Update(InsertOrUpdateRoleInput input)
        {
            if (input.Id < 0) { throw new UserFriendlyException("请传个要修改的Id过来"); }
            var role = _roleRepository.Get(input.Id);
            role.Name = input.Name;
            role.Remark = input.Remark;
            _roleRepository.Update(role);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var role = _roleRepository.Get(id);
            if (role.IsNullOrEmpty()) { throw new UserFriendlyException("请传个要删除的Id过来"); }
            _roleRepository.Delete(role);
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id">角色Id</param>
        /// <returns></returns>
        public RoleDto Get(int id)
        {
            if (id < 0) { throw new UserFriendlyException("请传个查询详细信息Id过来"); }
            return _roleRepository.Get(id).MapTo<RoleDto>();
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public IList<RoleDto> GetAll()
        {
            var list = _roleRepository.GetAll().OrderBy(x => x.Id).ToList();
            return list.MapTo<IList<RoleDto>>();
        }
        #endregion

        #region RolePermission
        /// <summary>
        /// 为角色添一个权限
        /// </summary>
        /// <param name="rolePermission">对象</param>
        public void AddPermission(RolePermissionDto rolePermission)
        {
            var rp = new RolePermission();
            rp.RoleId = rolePermission.RoleId;
            rp.PermissionId = rolePermission.PermissionId;
            _rolePermissionRepository.Insert(rp);
        }

        /// <summary>
        /// 删除对应角色的所有权限
        /// </summary>
        /// <param name="roleId">角色Id</param>
        public void DeleteAllPermissions(int roleId)
        {
            _rolePermissionRepository.Delete(x => x.RoleId == roleId);
        }

        /// <summary>
        /// 获取角色的所有权限
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public IList<RolePermissionDto> GetPermissions(int roleId)
        {
            var list = _rolePermissionRepository.GetAll().Where(x => x.RoleId == roleId).ToList();

            return list.MapTo<IList<RolePermissionDto>>();
        }

        /// <summary>
        /// 获取对应角色的所有权限
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public IList<RolePermissionDto> GetPermissions(List<int> roleIds)
        {
            var list = _rolePermissionRepository.GetAll().Where(x => roleIds.Contains(x.RoleId)).ToList();

            return list.MapTo<IList<RolePermissionDto>>();
        }
        #endregion
    }
}
