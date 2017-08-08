﻿using System;
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
        /// <param name="objKey">配置所属的项目KEY</param>
        /// <param name="name">配置项名称</param>
        /// <returns></returns>
        string GetAttrValue(string objKey, string name);
    }
}
