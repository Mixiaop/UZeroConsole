using System;
using U.Domain.Entities;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain
{
    /// <summary>
    /// 代表一个“菜单权限”
    /// </summary>
    public class Permission : Entity, IHasCreationTime, ISoftDelete
    {
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
        /// 创建时间
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 就否删除
        /// </summary>
        public virtual bool IsDeleted { get; set; }
    }
}
