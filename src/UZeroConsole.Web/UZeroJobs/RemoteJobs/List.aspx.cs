using System;
using AjaxPro;
using U;
using U.Utilities.Web;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Jobs;
using UZeroConsole.Services.Jobs;

namespace UZeroConsole.Web.UZeroJobs.RemoteJobs
{
    public partial class List : AuthPageBase
    {
        IRemoteJobService _remoteJobService = UPrimeEngine.Instance.Resolve<IRemoteJobService>();

        protected ListModel Model = new ListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.AjaxServices.UZeroJobs.RemoteJobService));
            if (!IsPostBack)
            {
                BindPageData();
            }
        }

        void BindPageData()
        {
            PagingInfo pageInfo = new PagingInfo();
            pageInfo.PageIndex = WebHelper.GetInt("page", 1);
            pageInfo.PageSize = 10;
            pageInfo.Url = WebHelper.GetUrl();

            Model.Results = _remoteJobService.Query("", null, pageInfo.PageIndex, pageInfo.PageSize);
            pageInfo.TotalCount = Model.Results.TotalCount;
            Model.PaginHTML = new Paginations(pageInfo).GetPaging();
        }
    }

    public class ListModel
    {
        public PagedResultDto<RemoteJob> Results { get; set; }

        public string PaginHTML { get; set; }
    }
}