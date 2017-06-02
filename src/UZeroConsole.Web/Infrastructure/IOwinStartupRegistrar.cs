using Owin;

namespace UZeroConsole.Web.Infrastructure
{
    /// <summary>
    /// Owin 启动注册器
    /// </summary>
    public interface IOwinStartupRegistrar : U.Dependency.ITransientDependency
    {
        void Register(IAppBuilder app);
    }
}