using System;
using U;
using U.FakeMvc.UI;
using U.Utilities.Web;
using U.FakeMvc.Controllers;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web
{
    public class AuthPageBase : PageBase
    {
        public AdminDto CurrentAdmin;

        //public UZeroConsoleWebLogService Logger = UPrimeEngine.Instance.Resolve<UZeroConsoleWebLogService>();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            IAuthenticationService authService = UPrimeEngine.Instance.Resolve<IAuthenticationService>();

            CurrentAdmin = authService.GetAuthenticatedAdmin();

            if (CurrentAdmin == null)
            {
                Context.Response.Write("<script>parent.window.location.href='/SysLogin.aspx?redirectUrl=" + WebHelper.GetUrl() + "';</script>");
                Context.Response.End();
                return;
            }
        }

        #region Logging
        public void LogInsert(string func, string funcContent)
        {
            //Logger.LogInsertAsync("Admin", CurrentAdmin.Name, string.Format("{0}【{1}】", func, funcContent), "", CurrentAdmin.Id);
        }

        public void LogUpdate(string func, string funcContent)
        {
           // Logger.LogUpdateAsync("Admin", CurrentAdmin.Name, string.Format("{0}【{1}】", func, funcContent), "", CurrentAdmin.Id);
        }

        public void LogDelete(string func, string funcContent)
        {
           // Logger.LogDeleteAsync("Admin", CurrentAdmin.Name, string.Format("{0}【{1}】", func, funcContent), "", CurrentAdmin.Id);
        }

        public void LogQuery(string func, string funcContent)
        {
          //  Logger.LogQueryAsync("Admin", CurrentAdmin.Name, string.Format("{0}【{1}】", func, funcContent), "", CurrentAdmin.Id);
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
           // Logger.LogExceptionAsync("Admin", CurrentAdmin.Name, message, ex.ToString(), CurrentAdmin.Id);
        }
        #endregion

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

    public abstract class AuthPageBase<TCtrl, TModel> : PageBase<TCtrl, TModel> where TCtrl : ControllerBase
    {
        public AdminDto CurrentAdmin;

        //public UZeroConsoleWebLogService Logger = UPrimeEngine.Instance.Resolve<UZeroConsoleWebLogService>();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            IAuthenticationService authService = UPrimeEngine.Instance.Resolve<IAuthenticationService>();

            CurrentAdmin = authService.GetAuthenticatedAdmin();

            if (CurrentAdmin == null)
            {
                Context.Response.Write("<script>parent.window.location.href='/SysLogin.aspx';</script>");
                Context.Response.End();
                return;
            }
        }

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
}