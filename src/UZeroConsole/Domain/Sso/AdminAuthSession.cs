using System;
using U.Domain.Entities;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Sso
{
    /// <summary>
    /// 开启Sso时，代表一个管理员的Session
    /// </summary>
    public class AdminAuthSession : Entity, IHasCreationTime
    {
        public AdminAuthSession() {
            SessionKey = "";
            AppKeys = "";
            AuthedAppKeys = "";
            AdminId = 0;
            IpAddress = "";
            ExpiresTime = DateTime.Now;
        }
        /// <summary>
        /// session key
        /// </summary>
        public string SessionKey { get; set; }

        /// <summary>
        /// 当前需要登录的应用
        /// </summary>
        public string CurrentAppKey { get; set; }

        /// <summary>
        /// 需要登录授权的应用（所有有权限的应用），逗号分割“,”
        /// </summary>
        public string AppKeys { get; set; }

        /// <summary>
        /// 已授权的Keys
        /// </summary>
        public string AuthedAppKeys { get; set; }

        /// <summary>
        /// 登录的管理员Id
        /// </summary>
        public int AdminId { get; set; }

        /// <summary>
        /// 登录的IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpiresTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 登录的管理员信息
        /// </summary>
        public virtual Admin Admin { get; set; }
    }
}
