namespace UZeroConsole.Services.External.Dto
{
    /// <summary>
    /// 应用支持推送文本、图片、视频、文件、图文等类型。
    /// 
    /// 请求示例
    /// {
    /// "touser" : "UserID1|UserID2|UserID3",
    /// "toparty" : "PartyID1|PartyID2",
    /// "totag" : "TagID1 | TagID2",
    /// "msgtype" : "text",
    /// "agentid" : 1,
    /// "text" : {
    ///        "content" : "你的快递已到，请携带工卡前往邮件中心领取。\n出发前可查看<a href=\"http://work.weixin.qq.com\">邮件中心视频实况</a>，聪明避开排队。"
    ///  },
    /// "safe":0
    /// }
    /// </summary>
    public class CorpWeixinSendMessageDto
    {
        public CorpWeixinSendMessageDto()
        {
            safe = 0;
            msgtype = "text";
            text = new CorpWeixinSendMessageContentDto();
        }

        public string touser { get; set; }

        public string toparty { get; set; }

        public string totag { get; set; }

        public string msgtype { get; set; }

        public string agentid { get; set; }

        public CorpWeixinSendMessageContentDto text { get; set; }

        public int safe { get; set; }
    }

    public class CorpWeixinSendMessageContentDto
    {
        public string content { get; set; }
    }
}
