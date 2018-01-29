using UZeroConsole.Monitoring.SQL;

namespace UZeroConsole.Web.Models.Monitoring.SQL
{
    public class DashboardModel
    {
        public SQLInstance CurrentInstance { get; set; }
        public string ErrorMessage { get; set; }

        public int Refresh { get; set; }
        public enum LastRunInterval
        {
            FiveMinutes = 5 * 60,
            Hour = 60 * 60,
            Day = 24 * 60 * 60,
            Week = 7 * 24 * 60 * 60
        }
    }
}