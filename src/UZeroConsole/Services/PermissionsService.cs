using System;
using System.Collections.Generic;
using System.Linq;
using U.AutoMapper;
using U.UI;
using U.Domain.Entities;
using UZeroConsole.Domain;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services
{
    public class PermissionsService : IPermissionsService
    {
        #region Fields & Ctor
        private readonly IPermissionRepository _permissionRepository;

        public PermissionsService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;

        }
        #endregion

        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="input"></param>
        public void Insert(InsertOrUpdatePermissionInput input)
        {
            if (string.IsNullOrEmpty(input.Name))
            {
                throw new UserFriendlyException("请输入菜单名称");
            }
            var permission = new Permission();
            permission.Name = input.Name;
            permission.Url = input.Url;
            permission.Icon = input.Icon;
            permission.Level = input.Level;
            permission.Order = input.Order;
            permission.ParentId = input.ParentId;
            permission.CreationTime = DateTime.Now;
            _permissionRepository.Insert(permission);
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="input"></param>
        public void Update(InsertOrUpdatePermissionInput input)
        {
            var permission = _permissionRepository.Get(input.Id);
            if (permission == null)
            {
                throw new UserFriendlyException("未找到权限");
            }

            permission.Name = input.Name;
            permission.Url = input.Url;
            permission.Icon = input.Icon;
            permission.Level = input.Level;
            permission.Order = input.Order;
            permission.ParentId = input.ParentId;
            _permissionRepository.Update(permission);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var admin = _permissionRepository.Get(id);
            if (admin.IsNullOrEmpty())
            {
                throw new UserFriendlyException("id不能为空");
            }

            _permissionRepository.Delete(admin);
        }

        /// <summary>
        /// 根据菜单栏Id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PermissionDto Get(int id)
        {
            if (id <= 0)
            {
                throw new UserFriendlyException("请传入要查询的Id");
            }
            return _permissionRepository.Get(id).MapTo<PermissionDto>();
        }


        /// <summary>
        /// 获取所有权限列表
        /// </summary>
        /// <returns></returns>
        public IList<PermissionDto> GetAll()
        {
            var list = _permissionRepository.GetAll().OrderBy(x => x.Order).ToList();
            return list.MapTo<List<PermissionDto>>();
        }
    }
}
