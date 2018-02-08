using System.Linq;
using U.Application.Services.Dto;
using U.Net.Mail;
using UZeroConsole.Configuration.Monitoring;
using UZeroConsole.Monitoring;
using UZeroConsole.Monitoring.SQL;
using UZeroConsole.Services.External;

namespace UZeroConsole.Services.Monitoring
{
    public class CallThePoliceService : ICallThePoliceService
    {
        private readonly AlertSettings _settings;
        private readonly ClientHostSettings _clientHostSettings;
        private readonly IEmailSender _emailSender;
        private readonly ICorpWeixinService _corpWeixinService;
        public CallThePoliceService(AlertSettings settings, ClientHostSettings clientHostSettings, IEmailSender emailSender, ICorpWeixinService corpWeixinService)
        {
            _settings = settings;
            _clientHostSettings = clientHostSettings;
            _emailSender = emailSender;
            _corpWeixinService = corpWeixinService;
        }
        /// <summary>
        /// 检查如果指标超出则通知
        /// </summary>
        /// <returns></returns>
        public StateOutput CheckOrCall()
        {
            StateOutput res = new StateOutput();

            if (_settings == null)
            {
                res.AddError("AlertSettings is null");
                return res;
            }

            //Web Servers
            foreach (var host in _clientHostSettings.Hosts)
            {
                if (host.CPUUsagePercent > _settings.WebServerCPUWarning)
                {
                    var subject = string.Format("【Web Server】{0}：CPU超出警告值（{1}）", host.Name, _settings.WebServerCPUWarning);

                    _corpWeixinService.SendMessage(_settings.CorpWeixinIdList, subject);
                }

                if (host.RAMUsedPercent > _settings.WebServerMemoryWarning) {
                    var subject = string.Format("【Web Server】{0}：Memory超出警告值（{1}）", host.Name, _settings.WebServerMemoryWarning);

                    _corpWeixinService.SendMessage(_settings.CorpWeixinIdList, subject);
                }
            }

            //SQL
            if (SQLModule.StandaloneInstances.Any()) {
                SQLModule.StandaloneInstances.ForEach((instance) => {
                    if (instance.CurrentCPUPercent.HasValue && instance.CurrentCPUPercent.Value > _settings.SqlCPUWarning) {
                        var subject = string.Format("【Sql Server】{0}：CPU超出警告值（{1}）", instance.Name, _settings.SqlCPUWarning);

                        _corpWeixinService.SendMessage(_settings.CorpWeixinIdList, subject);
                    }

                    if (instance.CurrentMemoryPercent.HasValue)
                    {
                        if (instance.CurrentMemoryPercent.Value > _settings.SqlMemoryWarning) {
                            var subject = string.Format("【Sql Server】{0}：Memory超出警告值（{1}）", instance.Name, _settings.SqlMemoryWarning);

                            _corpWeixinService.SendMessage(_settings.CorpWeixinIdList, subject);
                        }

                    }
                });
            }

            //Redis
            //var redisInstances = RedisInstance.GetAll("");
            //if (redisInstances.Any()) {

            //    foreach (var instance in redisInstances.OrderBy(m => m.Port).ThenBy(m => m.Name)) {
            //        redisInstances.Sum(i => i.Info?.Data?.Stats?.InstantaneousOpsPerSec ?? 0).ToComma().ToString();
            //    }
            //}
            return res;
        }
    }
}
