﻿using AjaxPro;
using System;
using System.Collections.Generic;
using U;
using U.Application.Services.Dto;
using U.Utilities.Web;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging;
using UZeroConsole.Services.Logging.Dto;

namespace UZeroConsole.Web.UZeroLogging.ActionLogs
{
    public partial class List : AuthPageBase
    {
        ILogAppService _appService = UPrimeEngine.Instance.Resolve<ILogAppService>();
        IActionLogService _logService = UPrimeEngine.Instance.Resolve<IActionLogService>();

        protected ListModel Model = new ListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.AjaxServices.UZeroLogging.ActionLogService));

            Model.App = _appService.Get(Model.GetAppId);
            Model.Modules = _logService.GetAllModules(Model.GetAppId);

            if (Model.App == null)
                Response.Redirect("../LogApps/List.aspx");
            if (!IsPostBack)
            {
                BindPageData();
            }
        }

        void BindPageData()
        {
            PagingInfo pageInfo = new PagingInfo();
            pageInfo.PageIndex = Model.GetPage;
            pageInfo.PageSize = 20;
            pageInfo.Url = WebHelper.GetUrl();

            DateTime? fromDate = null;
            DateTime? toDate = null;
            if (Model.GetFromTime.IsNotNullOrEmpty())
                fromDate = Model.GetFromTime.ToDateTime();

            if (Model.GetToTime.IsNotNullOrEmpty())
                toDate = Model.GetToTime.ToDateTime();


            Model.Results = _logService.Search(Model.GetAppId, Model.GetModule, "", Model.GetKeywords.Trim(), fromDate, toDate,
                                               pageInfo.PageIndex,
                                               pageInfo.PageSize);

            pageInfo.TotalCount = Model.Results.TotalCount;

            Model.PagingHTML = new Paginations(pageInfo).GetPaging();

            rptDatas.DataSource = Model.Results.Items;
            rptDatas.DataBind();
        }
    }

    public class ListModel
    {
        public int GetAppId { get { return WebHelper.GetInt("appId", 0); } }

        public string GetFromTime { get { return WebHelper.GetString("from"); } }

        public string GetToTime { get { return WebHelper.GetString("to"); } }

        public string GetModule { get { return WebHelper.GetString("module"); } }

        public string GetKeywords { get { return WebHelper.GetString("wd"); } }
        public int GetPage { get { return WebHelper.GetInt("page", 1); } }

        public LogApp App { get; set; }

        public IList<ActionModule> Modules { get; set; }
        public PagedResultDto<ActionLogDto> Results { get; set; }

        public string PagingHTML { get; set; }
    }
}