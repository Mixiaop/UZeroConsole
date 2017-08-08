using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging.Dto;

namespace UZeroConsole.Logging
{
    /// <summary>
    /// 日志模块服务
    /// 接管错误异常处理，及记录活动日志。（调用日志中心的SOA接口）
    /// </summary>
    public interface ILoggingClientService : U.Application.Services.IApplicationService
    {
        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="appKey">应用密钥</param>
        void HandleException(Exception ex, string appKey = "");

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="appKey">应用密钥</param>
        Task HandleExceptionAsync(Exception ex, string appKey = "");

        /// <summary>
        /// 记录活动日志
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="operateType">操作类型</param>
        /// <param name="shortMessage">短消息</param>
        /// <param name="operatorName">操作者</param>
        /// <param name="operatorId">操作者标识</param>
        /// <param name="fullMessage">详细消息</param>
        /// <param name="remark">其他备注</param>
        /// <param name="appKey">应用密钥</param>
        void Log(string moduleName = "", ActionLogOperateType operateType = ActionLogOperateType.None,
                 string shortMessage = "", string operatorName = "", string operatorId = "", string fullMessage = "", string remark = "", string appKey = "");

        /// <summary>
        /// 记录活动日志
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="operateType">操作类型</param>
        /// <param name="shortMessage">短消息</param>
        /// <param name="operatorName">操作者</param>
        /// <param name="operatorId">操作者标识</param>
        /// <param name="fullMessage">详细消息</param>
        /// <param name="remark">其他备注</param>
        /// <param name="appKey">应用密钥</param>
        Task LogAsync(string moduleName = "", ActionLogOperateType operateType = ActionLogOperateType.None,
                 string shortMessage = "", string operatorName = "", string operatorId = "", string fullMessage = "", string remark = "", string appKey = "");

        #region Search ActionLogs
        /// <summary>
        /// 获取TOP 的活动日志
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="operatorId"></param>
        /// <param name="topCount"></param>
        /// <returns></returns>
        IList<ActionLogTopDto> GetActionTopLogs(string appKey, string operatorId, int topCount = 10);
        #endregion
    }
}
