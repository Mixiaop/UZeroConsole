using U.CodeAnnotations;

namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 参数类型
    /// </summary>
    public enum ParamType
    {
        /// <summary>
        /// 文本框(单行)
        /// </summary>
        [EnumAlias("文本框(单行)")]
        Text = 0,
        /// <summary>
        /// 文本框(多行）
        /// </summary>
        [EnumAlias("文本框(多行）")]
        TextArea = 1,
        /// <summary>
        /// 单选
        /// </summary>
        [EnumAlias("单选")]
        Radio = 2,
        /// <summary>
        /// 下拉列表
        /// </summary>
        [EnumAlias("下拉列表")]
        DropDownList = 3,
        /// <summary>
        /// 图片
        /// </summary>
        [EnumAlias("图片")]
        UploadImage = 4,
        /// <summary>
        /// 附件
        /// </summary>
        [EnumAlias("附件")]
        UploadFile = 5,
        /// <summary>
        /// 内容编辑器
        /// </summary>
        [EnumAlias("内容编辑器")]
        ContentEditor = 6
    }

    /// <summary>
    /// 内容排序 
    /// </summary>
    public enum ContentOrderBy
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        Taxis = 0,
        /// <summary>
        /// 时间倒序
        /// </summary>
        CreationTimeDesc = 1,
        /// <summary>
        /// 时间正序
        /// </summary>
        CreationTime = 2
    }
}
