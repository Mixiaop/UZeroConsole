using System.Collections;
using System.Collections.Generic;
using U.Domain.Entities;
using UZeroConsole.Domain.Sso;

namespace UZeroConsole.Domain
{
    /// <summary>
    /// 代表一个控制台“角色”
    /// </summary>
    public class Role : Entity, ISoftDelete
    {
        /// <summary>
        /// 应用Id（开启Sso时使用）
        /// </summary>
        public int SsoAppId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        #region ISoftDelete
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }
        #endregion

        /// <summary>
        /// 应用（开启Sso时使用）
        /// </summary>
        public virtual App SsoApp { get; set; }

    }
}
