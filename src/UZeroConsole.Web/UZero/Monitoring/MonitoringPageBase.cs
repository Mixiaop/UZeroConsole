using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UZeroConsole.Monitoring;
using UZeroConsole.Monitoring.SQL;

namespace UZeroConsole.Web.UZero.Monitoring
{
    public class MonitoringPageBase : AuthPageBase
    {
        public static class HtmlHelper
        {
            public static string HealthDescription(IEnumerable<IMonitorStatus> ims, bool unknownIsHealthy = false)
            {
                var html = "";
                var warning = ims.Where(ag => ag.MonitorStatus == MonitorStatus.Warning).ToList();
                var good = ims.Where(ag => ag.MonitorStatus == MonitorStatus.Good || (unknownIsHealthy && ag.MonitorStatus == MonitorStatus.Unknown)).ToList();
                var bad = ims.Except(warning).Except(good).ToList();

                if (bad.Any())
                {
                    html += string.Format("{0} {1}", MonitorStatus.Critical.IconSpan(), bad.Count.ToComma());

                }
                if (warning.Any())
                {
                    html += string.Format("{0} {1}", MonitorStatus.Warning.IconSpan(), warning.Count.ToComma());
                }
                if (good.Any())
                {
                    html += string.Format("{0} {1}", MonitorStatus.Good.IconSpan(), good.Count.ToComma());
                }
                return html;
            }
        }

        public static class HtmlSQLHelper
        {
            public static string ConnectionsCell(SQLInstance i)
            {
                string html = "";
                var props = i.ServerProperties.SafeData(true);
                html = string.Format("<a><td class=\"text-center\">{0} <span class=\" text-default-light\">/ {1}</span></td></a>",
                                                                                       props.ConnectionCount.ToComma(),
                                                                                       props.SessionCount.ToComma());

                return html;
            }

            public static string MemoryCell(SQLInstance i, int decimalPlaces = 2)
            {
                string html = "";
                var props = i.ServerProperties.SafeData();
                if (props != null && props.PhysicalMemoryBytes > 0)
                {
                    html = string.Format("<td class=\"text-center\" title=\"{0}/{1}\">{2} %</td>",
                                                          props.CommittedBytes.ToSize(),
                                                          props.PhysicalMemoryBytes.ToSize(),
                                                          (decimal.Round(i.CurrentMemoryPercent.Value, decimalPlaces)));
                }
                else
                {
                    html = "<td class=\"text-center\">?</td>";
                }

                return html;
            }

            public static string BatchesCell(SQLInstance i)
            {
                return string.Format("<td class=\"text-center\">{0}</td>", i.BatchesPerSec?.ToComma());
            }
        }
    }

}