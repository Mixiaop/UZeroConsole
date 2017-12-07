using System.Collections.Generic;
using UZeroConsole.Domain;

namespace UZeroConsole.Services
{
    /// <summary>
    /// 各模块使用的自定义标签服务
    /// </summary>
    public interface ITagService : IApplicationService
    {
        /// <summary>
        /// 查询标识
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        /// <returns></returns>

        IList<Tag> QueryTags(TagType type, int count = 0);

        /// <summary>
        /// 获取多少条热门的标签
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        IList<Tag> GetTopList(int top);

        /// <summary>
        /// 更新多个标签（如果不存在则添加，如果已存在则数量+1）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tagNames">多个标签用英文逗号（,）分开</param>
        /// <param name="userId"></param>
        void UpdateTags(TagType type, string tagNames, int userId = 0);

        /// <summary>
        /// 是否存在标签名称
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        bool ExistsTagName(TagType type, string tagName);

        /// <summary>
        /// 通过名称获取标签信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        Tag GetByName(TagType type, string tagName);
    }
}
