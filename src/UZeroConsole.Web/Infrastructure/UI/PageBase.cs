using System;
using U;
using U.Utilities.Web;
using U.FakeMvc.Controllers;
using UZeroConsole.Configuration;

namespace UZeroConsole.Web
{
    public class PageBase : System.Web.UI.Page
    {
        public ConsoleSettings Settings = UPrimeEngine.Instance.Resolve<ConsoleSettings>();

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            
            
        }

        #region Method
            #region Alert

        public string AlertSuccess(string message, string title = "", int timeoutByClose = 0)
        {
            return GetMessage(1, title, message, timeoutByClose);
        }

        public string AlertError(string message, string title = "", int timeoutByClose = 0)
        {
            return GetMessage(2, title, message, timeoutByClose);
        }

        /// <summary>
        /// 获取消息HTML
        /// </summary>
        /// <param name="type">1-成功,2-错误,3-警告</param>
        /// <param name="message"></param>
        /// <param name="timeClose">1秒=1000</param>
        /// <returns></returns>
        private string GetMessage(int type, string title, string message, int timeClose)
        {
            string html = "";
            switch (type)
            {
                case 1:
                    html = "<div class=\"alert alert-success\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + (title != "" ? "<strong>" + title + "</strong> " : "") + "" + message + "</div>";
                    break;
                case 2:
                    html = "<div class=\"alert alert-danger\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + (title != "" ? "<strong>" + title + "</strong> " : "") + "" + message + "</div>";
                    break;
                case 3:
                    html = "<div class=\"alert alert-warning\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + (title != "" ? "<strong>" + title + "</strong> " : "") + "" + message + "</div>";
                    break;
            }

            if (timeClose > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "alert-hidden", "<script>setTimeout(function(){$('.alert').remove();}," + timeClose + ");</script>");
            }

            return html;
        }
        #endregion

        /// <summary>
        /// 客服端延时跳转
        /// </summary>
        /// <param name="url">跳转地址</param>
        /// <param name="time">时间1000:1秒</param>
        public void RedirectByTime(string url, int time)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "RedirectByTime", "<script>setTimeout(function(){window.location='" + url + "';}," + time + ");</script>");
        }

        protected void RegisterScripts(string key, string scripts)
        {
            this.ClientScript.RegisterStartupScript(GetType(), key, scripts, true);
        }

        /// <summary>
        /// 替换Url参数值
        /// </summary>
        /// <param name="param">参数,例：node=</param>
        /// <param name="rep">替换字符串,例：node=1</param>
        /// <param name="url">Url地址字符串</param>
        /// <returns>string</returns>
        protected string ChangeUrlParam(string param, string rep, string url)
        {
            var szUrl = url;
            if (szUrl.IndexOf(param) == -1)
            {
                if (szUrl.IndexOf("?") == -1)
                {
                    szUrl += "?";
                }
                else
                {
                    szUrl += "&";
                }
                szUrl += rep;
            }
            else
            {
                szUrl = System.Text.RegularExpressions.Regex.Replace(szUrl, param + @"[\d]{0,10}", rep);
            }
            return szUrl;
        }
        #endregion
    }

    #region FakeMvc
    public abstract class PageBase<TCtrl, TModel> : U.FakeMvc.UI.PageBase<TCtrl, TModel> where TCtrl : ControllerBase
    {
        #region Logging
        public void LogInsert(string func, string funcContent)
        {
            //Logger.LogInsertAsync("Admin", CurrentAdmin.Name, string.Format("{0}【{1}】", func, funcContent), "", CurrentAdmin.Id);
        }

        public void LogUpdate(string func, string funcContent)
        {
            //Logger.LogUpdateAsync("Admin", CurrentAdmin.Name, string.Format("{0}【{1}】", func, funcContent), "", CurrentAdmin.Id);
        }

        public void LogDelete(string func, string funcContent)
        {
            //Logger.LogDeleteAsync("Admin", CurrentAdmin.Name, string.Format("{0}【{1}】", func, funcContent), "", CurrentAdmin.Id);
        }

        public void LogQuery(string func, string funcContent)
        {
            //Logger.LogQueryAsync("Admin", CurrentAdmin.Name, string.Format("{0}【{1}】", func, funcContent), "", CurrentAdmin.Id);
        }

        /// <summary>
        /// 记录日志错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex">错误详情</param>
        /// <param name="line">行号</param>
        /// <param name="provinceId">省份Id</param>
        /// <param name="course">科目</param>
        /// <param name="batch">批次</param>
        /// <param name="collegeId">院校Id</param>
        public void LogError(string message, Exception ex)
        {
            //Logger.LogExceptionAsync("Admin", CurrentAdmin.Name, message, ex.ToString(), CurrentAdmin.Id);
        }
        #endregion

        #region Alert

        public string AlertSuccess(string message, string title = "", int timeoutByClose = 0)
        {
            return GetMessage(1, title, message, timeoutByClose);
        }

        public string AlertError(string message, string title = "", int timeoutByClose = 0)
        {
            return GetMessage(2, title, message, timeoutByClose);
        }

        /// <summary>
        /// 获取消息HTML
        /// </summary>
        /// <param name="type">1-成功,2-错误,3-警告</param>
        /// <param name="message"></param>
        /// <param name="timeClose">1秒=1000</param>
        /// <returns></returns>
        private string GetMessage(int type, string title, string message, int timeClose)
        {
            string html = "";
            switch (type)
            {
                case 1:
                    html = "<div class=\"alert alert-success\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + (title != "" ? "<strong>" + title + "</strong> " : "") + "" + message + "</div>";
                    break;
                case 2:
                    html = "<div class=\"alert alert-danger\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + (title != "" ? "<strong>" + title + "</strong> " : "") + "" + message + "</div>";
                    break;
                case 3:
                    html = "<div class=\"alert alert-warning\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + (title != "" ? "<strong>" + title + "</strong> " : "") + "" + message + "</div>";
                    break;
            }

            if (timeClose > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "alert-hidden", "<script>setTimeout(function(){$('.alert').remove();}," + timeClose + ");</script>");
            }

            return html;
        }
        #endregion

        /// <summary>
        /// 客服端延时跳转
        /// </summary>
        /// <param name="url">跳转地址</param>
        /// <param name="time">时间1000:1秒</param>
        public void RedirectByTime(string url, int time)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "RedirectByTime", "<script>setTimeout(function(){window.location='" + url + "';}," + time + ");</script>");
        }

        public string GetBackUrlEncoded(string defaultName = "redirectUrl")
        {
            return defaultName + "=" + WebHelper.GetThisPageUrl(true).EncodeUTF8Base64();
        }

        public string GetBackUrlDecoded(string defaultUrl = "", string defaultName = "redirectUrl")
        {
            var url = WebHelper.GetString(defaultName).DecodeUTF8Base64();
            if (url.IsNotNullOrEmpty())
            {
                return url;
            }
            else
                return defaultUrl;
        }
    }
    #endregion
}