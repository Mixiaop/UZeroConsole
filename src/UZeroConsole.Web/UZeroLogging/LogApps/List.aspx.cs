using System;
using U;
using U.Utilities.Web;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging;

namespace UZeroConsole.Web.UZeroLogging.LogApps
{
    public partial class List : AuthPageBase
    {
        ILogAppService _appService = UPrimeEngine.Instance.Resolve<ILogAppService>();

        protected ListModel Model = new ListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindPageData();
            }
        }

        void BindPageData() {
            PagingInfo pageInfo = new PagingInfo();
            pageInfo.PageIndex = WebHelper.GetInt("page", 1);
            pageInfo.PageSize = 10;
            pageInfo.Url = WebHelper.GetUrl();

            Model.Results = _appService.Search("", pageInfo.PageIndex, pageInfo.PageSize);
            pageInfo.TotalCount = Model.Results.TotalCount;
            Model.PaginHTML = new Paginations(pageInfo).GetPaging();
        }
    }

    public class ListModel {
        public PagedResultDto<LogApp> Results { get; set; }

        public string PaginHTML { get; set; }
    }
}