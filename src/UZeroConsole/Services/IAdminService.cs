using U.Application.Services;
using U.Application.Services.Dto;
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
        /// 创建一个管理理员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        void Create(string username, string password, string name, int roleId, string remark = "");

        /// <summary>
        /// 更新一条管理员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        void Update(int adminId, string name, int roleId, string remark);


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
        /// 验证用户名或密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        AdminDto Validation(string username, string password);

        /// <summary>
        /// 删除一条管理员信息
        /// </summary>
        /// <param name="id">管理员Id</param>
        void Delete(int id);

        /// <summary>
        /// 根据Id获取单条管理员信息
        /// </summary>
        /// <param name="id">管理员Id</param>
        /// <returns></returns>
        AdminDto Get(int id);

        /// <summary>
        /// 分页获取管理员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PagedResultOutput<AdminDto> Search(SearchAdminInput input);
        #endregion

    }
}
