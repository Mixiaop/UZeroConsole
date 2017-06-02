using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using U;
using U.Utilities.Web;
//using UZeroLog.Domain;
//using UZeroLog.Configuration;
//using UZeroLog.Services;

namespace UZeroConsole.Web.UZero
{
    public partial class UZeroLogList : AuthPageBase
    {
        //ILogService _logService = UPrimeEngine.Instance.Resolve<ILogService>();

        //protected IList<LogModule> Modules;
        protected string PagerHtml;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Modules = _logService.GetModules();

                ddlModules.Items.Clear();
                foreach (var module in Modules)
                {
                    ddlModules.Items.Add(new ListItem(module.AppAlias + " 【" + module.ModuleAlias + "】", module.App + "-" + module.ModuleName));
                }

                ddlModules.Items.Insert(0, new ListItem("应用模块", ""));

                ddlModules.SelectedValue = WebHelper.GetString("module");
                ddlOperateType.SelectedValue = WebHelper.GetString("type");
                ddlIsException.SelectedValue = WebHelper.GetString("isexception");
                tbKeywords.Text = WebHelper.GetString("keywords");
                BindPageDatas(GetUrlParam(), true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindPageDatas(GetUrlParam(), false);
        }

        protected string GetUrlParam()
        {
            string cdi = "";
            if (tbKeywords.Text.IsNotNullOrEmpty())
            {
                if (cdi != "")
                    cdi += "&";
                cdi += "keywords=" + tbKeywords.Text;
            }

            if (ddlModules.SelectedValue.IsNotNullOrEmpty())
            {
                if (cdi != "")
                    cdi += "&";
                cdi += "module=" + ddlModules.SelectedValue;
            }

            if (ddlOperateType.SelectedValue != "-1")
            {
                if (cdi != "")
                    cdi += "&";
                cdi += "type=" + ddlOperateType.SelectedValue;

            }

            if (ddlIsException.SelectedValue != "-1")
            {
                if (cdi != "")
                    cdi += "&";
                cdi += "isexception=" + ddlIsException.SelectedValue;

            }

            if (WebHelper.GetString("page") != "")
            {
                if (cdi != "")
                    cdi += "&";
                cdi += "page=" + WebHelper.GetString("page");
            }
            return cdi;
        }

        protected string GetModuleAlias(string app, string moduleName)
        {
            string alias = "";
            var module = _logService.GetModules().Where(x => x.App == app && x.ModuleName == moduleName).FirstOrDefault();
            if (module != null)
            {
                alias = "<label class=\"label label-default\">" + module.AppAlias + " 【" + module.ModuleAlias + "】</label>";
            }
            return alias;
        }

        protected string GetOperateTypeAlias(int typeId)
        {
            string alias = "";
            switch (typeId)
            {
                case 10:
                    alias = "<label class=\"label label-success\">Insert</label>";
                    break;
                case 20:
                    alias = "<label class=\"label label-success\">Update</label>";
                    break;
                case 30:
                    alias = "<label class=\"label label-default\">Query</label>";
                    break;
                case 40:
                    alias = "<label class=\"label label-danger\">Delete</label>";
                    break;
            }

            return alias;
        }

        private void BindPageDatas(string url, bool PageInit)
        {
            PagingInfo pageInfo = new PagingInfo();
            pageInfo.PageIndex = PageInit ? WebHelper.GetInt("page", 1) : 1;
            pageInfo.PageSize = 20;
            pageInfo.Url = url == "" ? WebHelper.GetUrl() : "UZeroLogList.aspx?" + url;

            string app = "", moduleName = "";
            if (ddlModules.SelectedValue.IsNotNullOrEmpty())
            {
                string[] modules = ddlModules.SelectedValue.Split('-');
                app = modules[0];
                moduleName = modules[1];
            }

            var datas = _logService.Query(pageInfo.PageIndex, pageInfo.PageSize,
                app,
                moduleName,
                (OperateType)ddlOperateType.SelectedValue.ToInt(),
                ddlIsException.SelectedValue.ToInt(),
                tbKeywords.Text.Trim());

            rptDatas.DataSource = datas.Items;
            rptDatas.DataBind();
            pageInfo.TotalCount = datas.TotalCount;
            PagerHtml = new Paginations(pageInfo).GetPaging();
        }
    }
}