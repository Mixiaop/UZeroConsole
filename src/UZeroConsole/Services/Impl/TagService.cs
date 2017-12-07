using System.Linq;
using System.Collections.Generic;
using U.UI;
using UZeroConsole.Domain;
using UZeroConsole.Domain.Repositories;

namespace UZeroConsole.Services.Impl
{
    public class TagService : ApplicationServiceBase, ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IList<Tag> QueryTags(TagType type, int count = 0)
        {
            int typeId = (int)type;
            var query = _tagRepository.GetAll();
            query = query.Where(x => x.TypeId == typeId);
            query = query.OrderByDescending(x => x.Count);
            if (count > 0)
                query = query.Take(count);

            var list = query.ToList();

            return list;
        }

        /// <summary>
        /// 获取多少条热门的标签
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public IList<Tag> GetTopList(int top)
        {
            var query = _tagRepository.GetAll();

            var list = query.OrderByDescending(x => x.Count).Take(top).ToList();
            return list;
        }

        /// <summary>
        /// 是否存在标签名称
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public bool ExistsTagName(TagType type, string tagName)
        {
            int typeId = (int)type;
            var count = _tagRepository.Count(x => x.TypeId == typeId && x.Name == tagName.Trim());
            return count > 0;
        }

        /// <summary>
        /// 更新多个标签（如果不存在则添加，如果已存在则数量+1）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tagNames">多个标签用英文逗号（,）分开</param>
        /// <param name="userId"></param>
        public void UpdateTags(TagType type, string tagNames, int userId = 0)
        {
            if (tagNames.IsNotNullOrEmpty())
            {
                tagNames = tagNames.Replace("，", ",");
                var tags = tagNames.Split(',');
                if (tags != null)
                {
                    foreach (var tag in tags)
                    {
                        if (ExistsTagName(type, tag))
                        {
                            //更新计数
                            var tagInfo = GetByName(type, tag);
                            if (tagInfo != null)
                            {
                                tagInfo.Count++;
                                _tagRepository.Update(tagInfo);
                            }
                        }
                        else
                        {
                            Tag tagInfo = new Tag();
                            tagInfo.Name = tag;
                            tagInfo.Alias = System.Web.HttpUtility.UrlEncode(tagInfo.Name);
                            tagInfo.Type = type;
                            tagInfo.UserId = userId;
                            _tagRepository.Insert(tagInfo);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 通过名称获取标签信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public Tag GetByName(TagType type, string tagName)
        {
            int typeId = (int)type;
            if (tagName.IsNullOrEmpty())
                throw new UserFriendlyException("标签名称不能为空");

            var tag = _tagRepository.GetAll().Where(x => x.TypeId == typeId && x.Name == tagName).FirstOrDefault();
            return tag;
        }
    }
}
