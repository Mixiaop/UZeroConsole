using System;
using U.Domain.Entities;
using U.Domain.Entities.Auditing;
using UZeroConsole.Domain.Sso;

namespace UZeroConsole.Domain
{
    /// <summary>
    /// 代表一个“菜单权限”
    /// </summary>
    public class Permission : Entity, IHasCreationTime, ISoftDelete
    {
        public Permission() {
            SsoAppId = 0;
            Name = "";
            Icon = "";
            Url = "";
            ParentId = 0;
            Level = 0;
            Order = 0;
            IsSystem = false;
        }

        /// <summary>
        /// 应用Id（开启Sso时使用）
        /// </summary>
        public int SsoAppId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// URL链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 父级权限Id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Level 
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 是否为系统权限（默认保留）
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 就否删除
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// Sso应用（开启Sso时使用）
        /// </summary>
        public virtual App SsoApp { get; set; }
    }
}
