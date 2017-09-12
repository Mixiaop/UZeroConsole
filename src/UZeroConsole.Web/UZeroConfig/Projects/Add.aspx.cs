using System;
using U;
using UZeroConsole.Domain.Config;
using UZeroConsole.Services.Config;

namespace UZeroConsole.Web.UZeroConfig.Projects
{
    public partial class Add : UZeroConsole.Web.AuthPageBase
    {
        IConfigService _configService = UPrimeEngine.Instance.Resolve<IConfigService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ConfigProject pro = new ConfigProject();
            pro.Name = tbName.Text.Trim();
            pro.Code = tbCode.Text.Trim();
            pro.Desc = tbDescription.Text.Trim();


            _configService.InsertProject(pro);

            ltlMessage.Text = AlertSuccess("添加成功");
            RedirectByTime(GetBackUrlDecoded("List.aspx"), 1000);
        }
    }
}
