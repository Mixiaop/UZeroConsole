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
        /// <returns></returns>
        IList<PermissionDto> GetAll();
    }
}
