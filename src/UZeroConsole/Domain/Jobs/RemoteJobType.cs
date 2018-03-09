
namespace UZeroConsole.Domain.Jobs
{
    public enum RemoteJobType : int
    {
        /// <summary>
        /// 普通的
        /// </summary>
        General = 10,
        /// <summary>
        /// 定时的
        /// </summary>
        AtTime = 20,
        /// <summary>
        /// 定时循环
        /// </summary>
        AtTimeRecurring = 21,
        /// <summary>
        /// 循环的
        /// </summary>
        Recurring = 30

    }
}
