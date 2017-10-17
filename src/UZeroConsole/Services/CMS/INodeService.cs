using UZeroConsole.Domain.CMS;

namespace UZeroConsole.Services.CMS
{
    /// <summary>
    /// 内容节点（栏目）的应用服务
    /// </summary>
    public interface INodeService : IApplicationService
    {
        /// <summary>
        /// 通过Id获取信息
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        Node Get(int nodeId);

        #region CUD
        /// <summary>
        /// 添加一个节点（同时会处理上下级、排序）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        int Insert(Node node);

        /// <summary>
        /// 更新一个节点 （同时会处理上下级、排序）
        /// </summary>
        /// <param name="node"></param>
        void Update(Node node);

        /// <summary>
        /// 删除一个节点 （同时会处理上下级、排序）
        /// </summary>
        /// <param name="nodeId"></param>
        void Delete(int nodeId);
        #endregion

        #region NodeGroup
        #endregion
    }
}
