
namespace UZeroConsole.Services.Logging.Dto
{
    /// <summary>
    /// 根据某个操作者排序操作日志
    /// </summary>
    public class ActionLogTopDto : U.Application.Services.Dto.IDto
    {
        public string ShortMessage { get; set; }

        public int Count { get; set; }
    }
}
