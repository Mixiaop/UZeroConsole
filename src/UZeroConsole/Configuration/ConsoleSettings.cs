﻿using U.Settings;

namespace UZeroConsole.Configuration
{
    [USettingsPathArribute("ConsoleSettings.json", "/Config/UZeroConsole")]
    public class ConsoleSettings : USettings<ConsoleSettings>
    {
        public bool IsDebug { get; set; }

        /// <summary>
        /// 应用名称（一般使用COOKIE或SESSION时当前缀使用）
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 控制台标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 是否使用Jobs应用（目前为 Hangfire 支持）
        /// </summary>
        public bool UseJobs { get; set; }

        /// <summary>
        /// 是否启动监控
        /// 启动：则会创建全局用的轮询后台线程
        /// </summary>
        public bool UseMonitoring { get; set; }

        /// <summary>
        /// 是否开启Sso
        /// </summary>
        public bool IsSsoOpend { get; set; }

        /// <summary>
        /// 是否为Sso服务端（false = 客户端）
        /// </summary>
        public bool IsSsoServer { get; set; }

        /// <summary>
        /// 默认一天，1440
        /// </summary>
        public int SsoAuthExpiresMinutes { get; set; }

        /// <summary>
        /// Sso服务端地址（客户端必填项）
        /// </summary>
        public string SsoServerHost { get; set; }

        /// <summary>
        /// 当前的Sso应用key
        /// </summary>
        public string SsoAppKey { get; set; }

        /// <summary>
        /// 是否开启UNote打通
        /// </summary>
        public bool UNoteExternalLoginOpened { get; set; }

        /// <summary>
        /// UNote自动登录URL
        /// </summary>
        public string UNoteExternalLoginUrl { get; set; }

        /// <summary>
        /// 开通 Unote 登录密钥
        /// </summary>
        public string UNoteAppKey { get; set; }

        /// <summary>
        /// 是否开启企业微信登录
        /// </summary>
        public bool IsCorpWeixinLoginOpened { get; set; }
    }
}
