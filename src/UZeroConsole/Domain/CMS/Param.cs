using System.Collections.Generic;
using System.Text.RegularExpressions;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 参数信息，栏目的自定义参数列表
    /// </summary>
    public class Param : CreationAuditedEntity
    {
        public Param() {
            ParamName = "";
            ParamType = ParamType.Text;
            Description = "";
            DefaultValue = "";
            ParamItems = "";
            ParamTypeDisplayName = "";
        }

        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParamName { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public ParamType ParamType { get; set; }

        /// <summary>
        /// 参数帮助提示
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 参数默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 参数项,例{Text:参数名称,Value:参数值}
        /// </summary>
        public string ParamItems { get; set; }

        /// <summary>
        /// 参数类型显示名称
        /// </summary>
        public string ParamTypeDisplayName { get; set; }

        /// <summary>
        /// 获取参数项
        /// </summary>
        /// <returns></returns>
        public List<ParamItem> GetParamItems()
        {
            List<ParamItem> list = new List<ParamItem>();
            if (!string.IsNullOrEmpty(this.ParamItems))
            {
                Regex reg = new Regex(@"{([\s\S]+?)}", RegexOptions.None);
                foreach (Match m in reg.Matches(this.ParamItems))
                {
                    string item = m.Groups[0].ToString();
                    string[] items = item.Replace("{", "").Replace("}", "").Split(',');
                    if (items.Length == 2)
                    {
                        list.Add(new ParamItem() { Text = items[0].Replace("Text:", ""), Value = items[1].Replace("Value:", "") });
                    }
                }
            }

            return list;
        }
    }

    /// <summary>
    /// 参数项
    /// </summary>
    public class ParamItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
