using U.Application.Services.Dto;

namespace UZeroConsole.Services.Installation
{
    /// <summary>
    /// 安装服务
    /// </summary>
    public interface IInstallationService : IApplicationService
    {
        /// <summary>
        /// 是否已安装
        /// </summary>
        /// <returns></returns>
        bool IsInstalled();

        /// <summary>
        /// 启动安装，初始化数据库表并创建管理员帐号（admin）等权限信息
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="adminPassword">管理员密码</param>
        /// <returns></returns>
        StateOutput Install(string connectionString, string adminPassword);
    }
}
