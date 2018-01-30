using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZeroConsole.Config
{
    /// <summary>
    /// 统一配置中心使用的客户端服务
    /// </summary>
    public interface IConfigClientService : U.Application.Services.IApplicationService
    {
        /// <summary>
        /// 获取某个配置的值
        /// </summary>
        /// <param name="name">配置项名称</param>
        /// <param name="objName">配置所属的对象名称，如果为空则在根目录</param>
        /// <returns></returns>
        string Get<T>(string name, string objName = "");

        /// <summary>
        /// 设置某个配置的项
        /// </summary>
        /// <param name="name">配置项名称</param>
        /// <param name="value">值</param>
        /// <param name="objName">配置所属的对象名称，如果为空则在根目录</param>
        /// <returns></returns>
        bool Set(string name, string value, string objName = "");
    }
}
