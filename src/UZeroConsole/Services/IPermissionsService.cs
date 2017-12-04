using System.Collections.Generic;
using U.Application.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services
{
    public interface IPermissionsService : IApplicationService
    {
        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="input"></param>
        void Insert(InsertOrUpdatePermissionInput input);

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="input"></param>
        void Update(InsertOrUpdatePermissionInput input);

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);


        /// <summary>
        /// 根据菜单栏Id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionDto Get(int id);

        /// <summary>
        /// 获取所有权限列表
        /// </summary>
        /// <param name="ssoAppId">Sso应用Id（开启Sso时使用）</param>
        /// <param name="filterSystem">是否过滤系统权限</param>
        /// <returns></returns>
        IList<PermissionDto> GetAll(int ssoAppId = 0, bool filterSystem = false);

        /// <summary>
        /// 获取所有系统权限菜单
        /// </summary>
        /// <returns></returns>
        IList<PermissionDto> GetAllBySystem();
    }
}
