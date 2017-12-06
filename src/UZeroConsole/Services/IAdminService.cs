using System.Collections.Generic;
using U.Application.Services.Dto;
using UZeroConsole.Domain;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services
{
    /// <summary>
    /// 管理员服务接口
    /// </summary>
    public interface IAdminService : IApplicationService
    {
        #region Admin
        /// <summary>
        /// 根据Id获取单条管理员信息
        /// </summary>
        /// <param name="id">管理员Id</param>
        /// <returns></returns>
        AdminDto Get(int id);

        /// <summary>
        /// 根据Id获取单条管理员信息
        /// </summary>
        /// <param name="id">管理员Id</param>
        /// <returns></returns>
        Admin GetEntity(int id);

        /// <summary>
        /// 分页获取管理员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PagedResultOutput<AdminDto> Search(SearchAdminInput input);

        /// <summary>
        /// 验证用户名或密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        AdminDto Validation(string username, string password);

        /// <summary>
        /// 创建一个管理理员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        void Create(string username, string password, string name, int roleId, string remark = "");

        /// <summary>
        /// 创建一个管理员（多角色）
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="roleIds"></param>
        /// <param name="remark"></param>
        void Create(string username, string password, string name, List<int> roleIds, string remark = "");

        /// <summary>
        /// 更新一条管理员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        void Update(int adminId, string name, int roleId, string remark);

        /// <summary>
        /// 更新一条管理员信息
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="roleIds"></param>
        /// <param name="remark"></param>
        /// <param name="unoteUsername"></param>
        void Update(int adminId, string name, List<int> roleIds, string remark, string unoteUsername = "");

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="newPassword"></param>
        void ResetPassword(int adminId, string newPassword);

        /// <summary>
        /// 更新最后更新时间
        /// </summary>
        /// <param name="adminId"></param>
        void UpdateLastLoginTime(int adminId);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ChangePasswordOutput ChangePassword(ChangePasswordInput input);

        /// <summary>
        /// 删除一条管理员信息
        /// </summary>
        /// <param name="id">管理员Id</param>
        void Delete(int id);
        #endregion

        #region CorpWeixin
        /// <summary>
        /// 通过企业微信UserId获取管理员信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        AdminDto GetByCorpWeixinUserId(string userId);

        /// <summary>
        /// 绑定企业微信帐号Id
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="corpWeixinUserId"></param>
        void BindCorpWeixin(int adminId, string corpWeixinUserId);
        #endregion

        /// <summary>
        /// 为管理员设置角色，设置时会清除原来的角色
        /// </summary>
        /// <param name="adminId">管理员Id</param>
        /// <param name="roleIds">角色Id列表</param>
        void SetRoles(int adminId, List<int> roleIds);
    }
}
