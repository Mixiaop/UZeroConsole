using System;
using System.Collections.Generic;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 内容信息描述
    /// </summary>
    public class Content : CreationAuditedEntity
    {
        public Content()
        {
            NodeId = 0;
            LastEditAdminName = "";
            LastEditDate = DateTime.Now;
            Hits = 0;
            Title = "";
            SubTitle = "";
            Summary = "";
            Body = "";
            Taxis = 0;
            ContentGroupNameCollection = "";
            AdminName = "";
            IsTop = 0;
            IsHot = 0;
            Status = 0;
            StatusRemark = "";
            StatusDisplayName = "";
            ImageCount = 0;
            ContentTags = "";
        }

        /// <summary>
        /// 栏目ID
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        /// 最后编辑用户名
        /// </summary>
        public string LastEditAdminName { get; set; }

        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime LastEditDate { get; set; }

        /// <summary>
        /// 点击量
        /// </summary>
        public int Hits { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 信息简介
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public int Taxis { get; set; }

        /// <summary>
        /// 内容组集合
        /// </summary>
        public string ContentGroupNameCollection { get; set; }

        /// <summary>
        /// 上传管理员名称
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public int IsTop { get; set; }

        /// <summary>
        /// 是否热点
        /// </summary>
        public int IsHot { get; set; }

        /// <summary>
        /// 内容状态[0:草稿,1:待审核,2:审核退稿,3:已审核]
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 审核状态备注
        /// </summary>
        public string StatusRemark { get; set; }

        /// <summary>
        /// 审核名称
        /// </summary>
        public string StatusDisplayName { get; set; }

        /// <summary>
        /// 图片数量
        /// </summary>
        public int ImageCount { get; set; }

        /// <summary>
        /// 内容的标签
        /// </summary>
        public string ContentTags { get; set; }

        #region Methods
        Dictionary<string, string> _params;
        Dictionary<string, string> Params
        {
            get
            {
                if (_params == null)
                {
                    _params = new Dictionary<string, string>();
                }
                return _params;
            }
        }

        public void AddParamItem(string text, string value)
        {
            Params.Add(text, value);
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public string this[string paramName]
        {
            get
            {
                if (IsExists(paramName))
                    return Params[paramName];
                else
                    return "";
            }
        }

        public bool IsExists(string paramName)
        {
            return Params.ContainsKey(paramName);
        }
        #endregion
    }
}
