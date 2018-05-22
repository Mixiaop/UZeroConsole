using System;
using System.Collections.Generic;
using System.Linq;
using UPrime.AutoMapper;
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
            permission.SsoAppId = input.SsoAppId;
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
        /// <param name="ssoAppId">Sso应用Id（开启Sso时使用）</param>
        /// <param name="filterSystem">是否过滤系统权限</param>
        /// <returns></returns>
        public IList<PermissionDto> GetAll(int ssoAppId = 0, bool filterSystem = false)
        {
            var query = _permissionRepository.GetAll();
            if (ssoAppId > 0)
            {
                query = query.Where(x => x.SsoAppId == ssoAppId);
            }

            if (filterSystem)
            {
                query = query.Where(x => x.IsSystem == false);
            }

            var list = query.OrderBy(x => x.Order).ToList();

            return list.MapTo<List<PermissionDto>>();
        }

        /// <summary>
        /// 获取所有系统权限菜单
        /// </summary>
        /// <returns></returns>
        public IList<PermissionDto> GetAllBySystem() {
            var query = _permissionRepository.GetAll();
            query = query.Where(x => x.IsSystem == true);

            var list = query.OrderBy(x => x.Order).ToList();

            return list.MapTo<List<PermissionDto>>();
        }
    }
}
