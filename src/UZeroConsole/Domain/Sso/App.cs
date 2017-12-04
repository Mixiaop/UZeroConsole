using System;
using U.Domain.Entities;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Sso
{
    /// <summary>
    /// 代表一个SSO应用
    /// 当配置开启Sso时，才会使用此业务，权限及菜单都会对应到应用。
    /// </summary>
    public class App : Entity, IHasCreationTime, ISoftDelete
    {
        public App() {
            AppKey = "";
            SecretKey = "";
            Name = "";
            Remark = "";
            ReturnUrl = "";
            IsSystem = false;
        }

        /// <summary>
        /// 应用KEY
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 应用返回URL（授权后）
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 是否系统（保留应用）
        /// </summary>
        public bool IsSystem { get; set; }

        #region IHasCreationTime, ISoftDelete
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreationTime { get; set; }
        #endregion

        public override string ToString()
        {
            return string.Format("{0}：{1}", Name, ReturnUrl);
        }
    }
}
