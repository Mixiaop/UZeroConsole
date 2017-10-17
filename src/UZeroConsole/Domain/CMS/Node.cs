using System;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 栏目信息描述类
    /// </summary>
    public class Node : CreationAuditedEntity
    {
        #region Ctor
        public Node()
        {
            NodeName = string.Empty;
            ParentId = 0;
            ParentsPath = string.Empty;
            NodeGroupNameCollection = string.Empty;
            PagePath = string.Empty;
            CreationTime = DateTime.Now;
            ImageUrl = "";
            NodeTypeId = 1;
            IsUseTag = 0;
            BGContentTaxisType = 1;
            BGContentPageSize = 10;
            BGContentTitle = "标题";
            BGContentTitleHelp = string.Empty;
            IsBGContentSubTitle = 1;
            BGContentSubTitle = "副标题";
            BGContentSubTitleHelp = string.Empty;
            IsBGContentSummary = 1;
            BGContentSummary = "内容简介";
            BGContentSummaryHelp = string.Empty;
            IsBGContentAttr = 1;
            BGContentAttr = "属性";
            BGContentAttrHelp = string.Empty;
            IsBGContentBody = 1;
            BGContentBody = "内容详情";
            BGContentBodyHelp = string.Empty;
        }
        #endregion

        /// <summary>
        /// 栏目名称
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 父栏目ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 父栏目路径描述例：1,3,5
        /// </summary>
        public string ParentsPath { get; set; }

        /// <summary>
        /// 父栏目数量
        /// </summary>
        public int ParentsCount { get; set; }

        /// <summary>
        /// 子栏目数量
        /// </summary>
        public int ChildrenCount { get; set; }

        /// <summary>
        /// 栏目内容数量
        /// </summary>
        public int ContentNum { get; set; }

        /// <summary>
        /// 1为最后一个节点 0否
        /// </summary>
        public int IsLastNode { get; set; }

        /// <summary>
        /// 栏目组集合
        /// </summary>
        public string NodeGroupNameCollection { get; set; }

        /// <summary>
        /// 栏目页路径
        /// </summary>
        public string PagePath { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Taxis { get; set; }

        /// <summary>
        /// 栏目图片
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// (1普通类型，2图片类型)
        /// </summary>
        public int NodeTypeId { get; set; }

        #region 栏目后台配置
        /// <summary>
        /// 是否使用标签
        /// </summary>
        public int IsUseTag { get; set; }

        /// <summary>
        /// 后台内容排序类型 (1默认排序，2时间倒序，3时间正序)
        /// </summary>
        public int BGContentTaxisType { get; set; }

        /// <summary>
        /// 后台内容列表每页显示数
        /// </summary>
        public int BGContentPageSize { get; set; }

        /// <summary>
        /// 内容列标题名称
        /// </summary>
        public string BGContentTitle { get; set; }

        /// <summary>
        /// 内容列标题名称
        /// </summary>
        public string BGContentTitleHelp { get; set; }

        /// <summary>
        /// 是否显示内容列副标题
        /// </summary>
        public int IsBGContentSubTitle { get; set; }

        /// <summary>
        /// 内容列副标题名称
        /// </summary>
        public string BGContentSubTitle { get; set; }

        /// <summary>
        /// 内容列副标题帮助介绍
        /// </summary>
        public string BGContentSubTitleHelp { get; set; }

        /// <summary>
        /// 是否显示内容列信息简介
        /// </summary>
        public int IsBGContentSummary { get; set; }

        /// <summary>
        /// 内容列信息简介
        /// </summary>
        public string BGContentSummary { get; set; }


        /// <summary>
        /// 内容列信息简介帮助介绍 
        /// </summary>
        public string BGContentSummaryHelp { get; set; }

        /// <summary>
        /// 是否显示内容列属性
        /// </summary>
        public int IsBGContentAttr { get; set; }

        /// <summary>
        /// 内容列属性名称
        /// </summary>
        public string BGContentAttr { get; set; }

        /// <summary>
        /// 内容列属性帮助介绍
        /// </summary>
        public string BGContentAttrHelp { get; set; }

        /// <summary>
        /// 是否显示内容列信息内容
        /// </summary>
        public int IsBGContentBody { get; set; }

        /// <summary>
        /// 内容列信息内容名称
        /// </summary>
        public string BGContentBody { get; set; }

        /// <summary>
        /// 内容列信息内容帮助介绍
        /// </summary>
        public string BGContentBodyHelp { get; set; }
        #endregion

        #region Method
        public string GetNodeTypeDisplayName()
        {
            switch (this.NodeTypeId)
            {
                case 1:
                    return "普通类型";
                case 2:
                    return "图片类型";
                default:
                    return "普通类型";
            }
        }
        #endregion
    }
}
