using System.Collections.Generic;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Config
{
    /// <summary>
    /// 代表一个“配置对象”
    /// 对象当然会有很多自定义的属性
    /// </summary>
    public class ConfigObject : CreationAuditedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 配置项目Id
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 配置项目
        /// </summary>
        public virtual ConfigProject Project { get; set; }

        #region Custom
        /// <summary>
        /// 配置属性列表
        /// </summary>
        public IList<ConfigAttr> Attrs { get; set; }
        #endregion

    }
}
