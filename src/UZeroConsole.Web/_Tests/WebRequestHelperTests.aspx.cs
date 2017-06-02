using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using U;
using U.Utilities.Net;
using U.WebApi.Client;

namespace UZeroConsole.Web._Tests
{
    public partial class WebRequestHelperTests : System.Web.UI.Page
    {
        IUWebApiClient webApiClient = UPrimeEngine.Instance.Resolve<IUWebApiClient>();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpGet1.Click += HttpGet1_Click;
            HttpGet2.Click += HttpGet2_Click;
            HttpPost.Click += HttpPost_Click;
        }

        void HttpPost_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("key", "d27b1eb4e55744729be0e4ec5657531c");
            formData.Add("key2", "123123");
            formData.Add("key3", "123123");
            formData.Add("key4", "123123");
            formData.Add("key5", "123123");
            formData.Add("key6", "123123");
            formData.Add("key7", "123123");
            formData.Add("key8", "123123");
            formData.Add("key9", "123123");
            formData.Add("key10", "123123");
            formData.Add("key11", "123123");
            formData.Add("key12", "123123");
            //var res = WebRequestHelper.HttpPost("http://localhost:8400/_Tests/WebRequestHelperPostReceiveTests.aspx", formData);
            var res = DoHttpPost("http://localhost:8400/_Tests/WebRequestHelperPostReceiveTests.aspx", formData);
            //var res = webApiClient.PostAsync("http://localhost:8400/_Tests/WebRequestHelperPostReceiveTests.aspx",formData);
            Response.Write("res：" + res);
        }

        void HttpGet2_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Auth", "123123");
            headers.Add("Sign", "321321");
            var html = WebRequestHelper.HttpGet("http://www.mbjuan.com", headers);
            Response.Write(html);
        }

        void HttpGet1_Click(object sender, EventArgs e)
        {
            var html = WebRequestHelper.HttpGet("http://www.mbjuan.com", null);
            Response.Write(html);
        }

        public string DoHttpPost(string url, Dictionary<string, string> formData = null, Dictionary<string, string> fileDict = null, string refererUrl = null, Dictionary<string, string> headers = null,
             Encoding encoding = null, CookieContainer cookieContainer = null, X509Certificate cer = null, int timeout = 10000)
        {
            MemoryStream postStream = new MemoryStream();
            formData.FillFormDataStream(postStream);//填充formData

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Timeout = timeout;
            request.Proxy = null;
            if (cer != null)
            {
                request.ClientCertificates.Add(cer);
            }



            #region 处理Form表单文件上传
            var formUploadFile = fileDict != null && fileDict.Count > 0;//是否用Form上传文件
            if (formUploadFile)
            {
                //通过表单上传文件
                postStream = postStream ?? new MemoryStream();

                string boundary = "----" + DateTime.Now.Ticks.ToString("x");
                //byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                string fileFormdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n";
                string dataFormdataTemplate = "\r\n--" + boundary +
                                                "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                foreach (var file in fileDict)
                {
                    try
                    {
                        var fileName = file.Value;
                        //准备文件流
                        using (var fileStream = U.Utilities.IO.FileHelper.GetFileStream(fileName))
                        {
                            string formdata = null;
                            if (fileStream != null)
                            {
                                //存在文件
                                formdata = string.Format(fileFormdataTemplate, file.Key, /*fileName*/ Path.GetFileName(fileName));
                            }
                            else
                            {
                                //不存在文件或只是注释
                                formdata = string.Format(dataFormdataTemplate, file.Key, file.Value);
                            }

                            //统一处理
                            var formdataBytes = Encoding.UTF8.GetBytes(postStream.Length == 0 ? formdata.Substring(2, formdata.Length - 2) : formdata);//第一行不需要换行
                            postStream.Write(formdataBytes, 0, formdataBytes.Length);

                            //写入文件
                            if (fileStream != null)
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead = 0;
                                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                                {
                                    postStream.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                //结尾
                var footer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                postStream.Write(footer, 0, footer.Length);

                request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            }
            else
            {
                request.ContentType = "application/x-www-form-urlencoded";
            }
            #endregion

            request.ContentLength = postStream != null ? postStream.Length : 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.KeepAlive = true;

            if (!string.IsNullOrEmpty(refererUrl))
            {
                request.Referer = refererUrl;
            }
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";

            if (cookieContainer != null)
            {
                request.CookieContainer = cookieContainer;
            }

            #region 输入二进制流
            if (postStream != null)
            {
                postStream.Position = 0;

                //直接写入流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                //debug
                //postStream.Seek(0, SeekOrigin.Begin);
                //StreamReader sr = new StreamReader(postStream);
                //var postStr = sr.ReadToEnd();

                postStream.Close();//关闭文件访问
            }
            #endregion

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (cookieContainer != null)
            {
                response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
            }

            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(responseStream, encoding ?? Encoding.GetEncoding("utf-8")))
                {
                    string retString = myStreamReader.ReadToEnd();
                    return retString;
                }
            }
        }
    }
}