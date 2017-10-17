using System;
using U;
using U.Utilities.Web;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Config;
using UZeroConsole.Services.Config;

namespace UZeroConsole.Web.UZeroConfig.Projects
{
    public partial class List : AuthPageBase
    {
        IConfigService _configService = UPrimeEngine.Instance.Resolve<IConfigService>();

        protected ListModel Model = new ListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PagingInfo pageInfo = new PagingInfo();
                pageInfo.PageIndex = WebHelper.GetInt("page", 1);
                pageInfo.PageSize = 20;
                pageInfo.Url = WebHelper.GetUrl();

                Model.Results = _configService.QueryProjects("", pageInfo.PageIndex, pageInfo.PageSize);
                pageInfo.TotalCount = Model.Results.TotalCount;
                Model.PaginHTML = new Paginations(pageInfo).GetPaging();
            }
        }
    }


    public class ListModel
    {
        public string GetKeywords { get { return WebHelper.GetString("wd"); } }

        public PagedResultDto<ConfigProject> Results { get; set; }

        public string PaginHTML { get; set; }
    }
}