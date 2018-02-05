using Newtonsoft.Json;
using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using System.Net.Http;
using System.Net.Http.Headers;

namespace UZeroConsole.WinServices.PerformanceSender
{
    partial class PerformanceSenderService : ServiceBase
    {
        Settings _settings => GetSettings();
        public PerformanceSenderService()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = _settings.SendInterval;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var client = PerformanceModule.Current();
            client.ClientId = _settings.ClientId;
            client.ClientName = _settings.ClientName;
            client.ClientIp = _settings.ClientIp;
            var json = JsonConvert.SerializeObject(client);
            var requestJson = JsonConvert.SerializeObject(json);
            
            HttpContent httpContent = new StringContent(requestJson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var httpClient = new HttpClient();

            try
            {
                httpClient.PostAsync(_settings.ServerHost, httpContent);
            }
            catch (Exception ex)
            {
                WriteError("出错了：" + ex.Message);
            }
        }

        protected override void OnStart(string[] args)
        {
            this.WriteLog("----------UZeroConsole监控服务已开启\r\n");
        }

        protected override void OnStop()
        {
            this.WriteLog("----------UZeroConsole监控服务已停止\r\n");
        }

        #region Settings
        private Settings GetSettings()
        {
            Settings settings = null;
            var filePath = AppDomain.CurrentDomain.BaseDirectory + @"\Settings.json";
            if (File.Exists(filePath))
            {
                var fileData = File.ReadAllText(filePath);
                settings = JsonConvert.DeserializeObject<Settings>(fileData);
            }
            else
            {
                WriteError("出错了：未找到配置文件" + filePath);
            }

            return settings;
        }

        public class Settings
        {
            public string ServerHost { get; set; }
            public string ClientIp { get; set; }
            public int ClientId { get; set; }
            public string ClientName { get; set; }
            public int SendInterval { get; set; }
        }
        #endregion

        #region Logs
        private void WriteLog(string message)
        {
            string path = string.Format(AppDomain.CurrentDomain.BaseDirectory + @"\logs\log-{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                FileStream fs;
                fs = File.Create(path);
                fs.Close();
            }

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "   " + message);
                }
            }
        }

        private void WriteError(string message)
        {
            string path = string.Format(AppDomain.CurrentDomain.BaseDirectory + @"\logs\error-{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                FileStream fs;
                fs = File.Create(path);
                fs.Close();
            }

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "   " + message);
                }
            }
        }
        #endregion
    }
}
