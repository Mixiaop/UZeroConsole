using System;
using U;
using U.Utilities.Web;
using U.FakeMvc.Controllers;
using UZeroConsole.Configuration;
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

    #region FakeMvc
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
    }
    #endregion
}