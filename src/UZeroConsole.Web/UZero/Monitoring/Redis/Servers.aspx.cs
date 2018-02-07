using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U.Utilities.Web;
using UZeroConsole.Monitoring.Redis;
using UZeroConsole.Web.Models.Monitoring.Redis;

namespace UZeroConsole.Web.UZero.Monitoring.Redis
{
    public partial class Servers : MonitoringPageBase
    {
        protected ServersModel Model = new ServersModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            var node = WebHelper.GetString("node");
            var instances = RedisInstance.GetAll(node);
            Model.Instances = instances.Count > 1 ? instances : RedisModule.Instances;
            Model.View = RedisViews.All;
            Model.CurrentRedisServer = node;
            Model.Refresh = true;
            Model.Prep();
        }

        protected string GetAllOps() {
            return Model.Instances.Sum(i => i.Info?.Data?.Stats?.TotalCommandsProcessed ?? 0).ToComma().ToString();
        }

        protected string GetAllOpsPerSec() {
            return Model.Instances.Sum(i => i.Info?.Data?.Stats?.InstantaneousOpsPerSec ?? 0).ToComma().ToString();
        }

        protected string GetAllMemory() {
            return Model.Instances.Sum(i => i.Info?.Data?.Memory?.UsedMemoryRSS ?? 0).ToHumanReadableSize().ToString();
        }

        protected string GetAllMemoryUsed() {
            return Model.Instances.Sum(i => i.Info?.Data?.Memory?.UsedMemory ?? 0).ToHumanReadableSize().ToString();
        }

        protected string GetAllClients() {
            return Model.Instances.Sum(i => i.Info?.Data?.Clients.Connected ?? 0).ToComma().ToString();
        }
    }
}