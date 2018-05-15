
namespace UZeroConsole
{
    public class UZeroConsoleConsts
    {

        /// <summary>
        /// 当前版本
        /// </summary>
        public const string CurrentVersion = "0.3.10.4";
    }
    //0.1.2.0  -增加了获取操作日志统计的接口方法
    //0.1.2.1  -操作日志更新【清除日志】的功能
    //0.1.3.1  -【日志、异常列表】增加了过滤的关键字
    //0.1.4.1  -增加了【远程计划任务功能】，用于定时、循环执行URL链接
    //0.1.4.2  -增加了U.FakeMvc.PageBase【不能登录验证】
    //0.1.5.2  -初版Sso结束
    //0.1.6.2  -Job新增标签分类搜索，修复【循环任务出错后就不执行的BUG】
    //         -提供自动安装应用
    //0.1.7.2  -新增UZeroConsole.Client.Jobs命名空间，提供客户端调用SOA运行任务项
    //0.1.7.3  -更新U 0.5.11.10
    //0.2.7.3  -合并了ClientService 至 UZeroConsole.Client
    //0.2.8.3  -监控win services
    //0.3.8.3  -后台新增监护页面SQL、Redis、Hosts
    //0.3.8.4  -新增定时循环
    //0.3.9.4  -取消了JOB应用，独立出项目Blackout
    //0.3.10.4 -升级了依赖库Extensions、AutoMapper
}
