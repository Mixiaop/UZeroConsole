namespace UZeroConsole.Services.External.Dto
{
    public class CorpWeixinSendMessageOutput
    {
        /// <summary>
        /// "userid1|userid2", // 不区分大小写，返回的列表都统一转为小写
        /// </summary>
        public string invaliduser { get; set; }

        public string invalidparty { get; set; }

        public string invalidtag { get; set; }
    }
}
