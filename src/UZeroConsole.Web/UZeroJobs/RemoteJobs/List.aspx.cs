using System;
using System.Collections.Generic;
using AjaxPro;
using U;
using U.Utilities.Web;
using U.Application.Services.Dto;
using UZeroConsole.Domain;
using UZeroConsole.Domain.Jobs;
using UZeroConsole.Services;
using UZeroConsole.Services.Jobs;

namespace UZeroConsole.Web.UZeroJobs.RemoteJobs
{
    public partial class List : AuthPageBase
    {
        ITagService _tagService = UPrimeEngine.Instance.Resolve<ITagService>();
        IRemoteJobService _remoteJobService = UPrimeEngine.Instance.Resolve<IRemoteJobService>();

        protected ListModel Model = new ListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.AjaxServices.UZeroJobs.RemoteJobService));
            Model.Tags = _tagService.QueryTags(TagType.Job);

            if (!IsPostBack)
            {
                BindPageData();
            }
        }

        void BindPageData()
        {
            PagingInfo pageInfo = new PagingInfo();
            pageInfo.PageIndex = WebHelper.GetInt("page", 1);
            pageInfo.PageSize = 40;
            pageInfo.Url = WebHelper.GetUrl();

            Model.Results = _remoteJobService.Query("", Model.GetTags, null, pageInfo.PageIndex, pageInfo.PageSize);
            pageInfo.TotalCount = Model.Results.TotalCount;
            Model.PaginHTML = new Paginations(pageInfo).GetPaging();
        }
    }

    public class ListModel
    {
        public string GetTags { get { return WebHelper.GetString("tags"); } }

        public IList<Tag> Tags { get; set; }

        public PagedResultDto<RemoteJob> Results { get; set; }

        public string PaginHTML { get; set; }

    }
}