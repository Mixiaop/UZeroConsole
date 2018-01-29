using System.Threading.Tasks;
using U.BackgroundJobs;
using U.Dependency;

namespace UZeroConsole.Monitoring
{
    /// <summary>
    /// 执行轮询节点的任务
    /// </summary>
    public class PollNodeJob : BackgroundJob<PollNode>, ITransientDependency
    {
        public override void Execute(PollNode node)
        {
            node.PollAsync();
        }
    }
}
