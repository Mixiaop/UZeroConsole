using System;
using System.Collections.Generic;
using U;
using UZeroConsole.Domain;
using UZeroConsole.Domain.Jobs;
using UZeroConsole.Services;
using UZeroConsole.Services.Jobs;

namespace UZeroConsole.Web.UZeroJobs.RemoteJobs
{
    public partial class Add : AuthPageBase
    {
        ITagService _tagService = UPrimeEngine.Instance.Resolve<ITagService>();
        IRemoteJobService _remoteJobService = UPrimeEngine.Instance.Resolve<IRemoteJobService>();

        protected AddModel Model = new AddModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            Model.Tags = _tagService.QueryTags(TagType.Job);

        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string key = tbKey.Text.Trim();
            string name = tbName.Text.Trim();
            string url = tbUrl.Text.Trim();
            string desc = tbDesc.Text.Trim();
            int typeId = ddlType.SelectedValue.ToInt();
            string strAtTime = tbAtTime.Text.Trim();
            string recurringTime = tbRecurringTime.Text.Trim();
            string tags = tbTags.Text.Trim();

            if (key.IsNullOrEmpty() || name.IsNullOrEmpty() || url.IsNullOrEmpty())
            {
                ltlMessage.Text = AlertError("【名称、Key、URL】不能为空");
                return;
            }

            if ((RemoteJobType)typeId == RemoteJobType.AtTime && strAtTime.IsNullOrEmpty())
            {
                ltlMessage.Text = AlertError("【定时时间】不能为空");
                return;
            }

            if ((RemoteJobType)typeId == RemoteJobType.Recurring && recurringTime.IsNullOrEmpty())
            {
                ltlMessage.Text = AlertError("【循环时间】不能为空");
                return;
            }
            DateTime? atTime = null;
            if (strAtTime.IsNotNullOrEmpty())
            {
                atTime = strAtTime.ToDateTime();
            }
            _remoteJobService.CreateJob(key, name, url, 0, desc, (RemoteJobType)typeId, recurringTime.ToInt(), atTime, tags);

            ltlMessage.Text = AlertSuccess("添加成功");
            RedirectByTime(GetBackUrlDecoded("List.aspx"), 1000);
        }
    }

    public class AddModel
    {
        public IList<Tag> Tags { get; set; }
    }
}