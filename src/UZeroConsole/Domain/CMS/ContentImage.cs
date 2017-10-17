using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 内容图片列表
    /// </summary>
    public class ContentImage : CreationAuditedEntity
    {
        public ContentImage() {
            ContentId = 0;
            Name = "";
            Intro = "";
            ImageUrl = "";
            ThumbUrl = "";
            SquareUrl = "";
        }

        /// <summary>
        /// 内容Id
        /// </summary>
        public int ContentId { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图片简介
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbUrl { get; set; }
        /// <summary>
        /// 小方块
        /// </summary>
        public string SquareUrl { get; set; }
    }
}
