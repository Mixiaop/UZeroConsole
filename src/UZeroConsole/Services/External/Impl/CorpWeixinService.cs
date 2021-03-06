﻿using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using U.Utilities.Net;
using UZeroConsole.Configuration;
using UZeroConsole.Services.External.Dto;

namespace UZeroConsole.Services.External.Impl
{
    public class CorpWeixinService : ICorpWeixinService
    {
        private readonly CorpWeixinSettings _settings;
        public CorpWeixinService(CorpWeixinSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// 获取访问令牌
        /// </summary>
        /// <returns></returns>
        public GetCorpWexinAccessTokenOutput GetAccessToken()
        {
            GetCorpWexinAccessTokenOutput res = new GetCorpWexinAccessTokenOutput();
            if (_settings.CorpId.IsNotNullOrEmpty() && _settings.AuthSecret.IsNotNullOrEmpty())
            {
                string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", _settings.CorpId, _settings.AuthSecret);
                var response = WebRequestHelper.HttpGet(url, Encoding.GetEncoding("utf-8"));

                if (response.IsNotNullOrEmpty())
                    res = JsonConvert.DeserializeObject<GetCorpWexinAccessTokenOutput>(response);
            }

            return res;
        }

        /// <summary>
        /// 获取用户Id
        /// </summary>
        /// <param name="accessToken">令牌</param>
        /// <param name="code">回调code</param>
        /// <returns></returns>
        public GetCorpWeixinUserIdOutput GetUserId(string accessToken, string code)
        {
            GetCorpWeixinUserIdOutput res = new GetCorpWeixinUserIdOutput();
            if (accessToken.IsNotNullOrEmpty() && code.IsNotNullOrEmpty())
            {
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}", accessToken, code);
                var response = WebRequestHelper.HttpGet(url, Encoding.GetEncoding("utf-8"));

                if (response.IsNotNullOrEmpty())
                    res = JsonConvert.DeserializeObject<GetCorpWeixinUserIdOutput>(response);
            }
            return res;
        }

        public CorpWeixinSendMessageOutput SendMessage(List<string> userIdList, string content)
        {
            CorpWeixinSendMessageOutput res = new CorpWeixinSendMessageOutput();

            GetCorpWexinAccessTokenOutput token = GetAccessToken();
            if (token.errmsg == "ok")
            {
                string accessToken = token.access_token;

                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", accessToken);

                CorpWeixinSendMessageDto input = new CorpWeixinSendMessageDto();

                if (userIdList != null)
                {
                    userIdList.ForEach((userId) => {
                        input.touser += userId + "|";
                    });

                    if (input.touser.IsNotNullOrEmpty())
                        input.touser = input.touser.TrimEnd("|");
                }
                input.agentid = _settings.AuthAgentId;
                input.text.content = content;
                var data = JsonConvert.SerializeObject(input);

                var response = WebRequestHelper.HttpPost(url, data);
                if (response.IsNotNullOrEmpty())
                    res = JsonConvert.DeserializeObject<CorpWeixinSendMessageOutput>(response);
            }
            return res;
        }
    }
}
