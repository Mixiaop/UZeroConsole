using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZeroConsole.Domain.CMS;
using UZeroConsole.Domain.CMS.Repositories;

namespace UZeroConsole.Services.CMS.Impl
{
    public class NodeService : ApplicationServiceBase, INodeService
    {
        #region Fields & Ctor
        private readonly INodeRepository _nodeRepository;
        private readonly INodeGroupRepository _nodeGroupRepository;
        public NodeService(INodeRepository nodeRepository, INodeGroupRepository nodeGroupRepository)
        {
            _nodeRepository = nodeRepository;
            _nodeGroupRepository = nodeGroupRepository;
        }
        #endregion

        /// <summary>
        /// 通过Id获取信息
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public Node Get(int nodeId)
        {
            return _nodeRepository.Get(nodeId);
        }

        #region CUD
        /// <summary>
        /// 添加一个节点（同时会处理上下级、排序）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int Insert(Node node)
        {
            var parentNode = Get(node.ParentId);
            if (parentNode != null)
            {
                //更新父栏目
                string parentsPath = parentNode.ParentsPath;
                parentNode.ChildrenCount += 1;
                Update(node);

                node.ParentsPath = parentsPath == string.Empty ? node.ParentId.ToString() : parentsPath + "," + node.ParentId;
                node.ParentsCount = parentNode.ParentsCount + 1;
            }

            int parentCount = _nodeRepository.Count(x => x.ParentId == node.ParentId);
            node.Taxis = parentCount + 1;

            int nodeId = _nodeRepository.InsertAndGetId(node);

            //修改最后节点标签
            this.ResetLastNodeAttr(node.ParentId);
            return nodeId;
        }

        /// <summary>
        /// 更新一个节点 （同时会处理上下级、排序）
        /// </summary>
        /// <param name="node"></param>
        public void Update(Node node)
        {
            _nodeRepository.Update(node);
        }

        /// <summary>
        /// 删除一个节点 （同时会处理上下级、排序）
        /// </summary>
        /// <param name="nodeId"></param>
        public void Delete(int nodeId)
        {
            throw new Exception();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 通过父Id获取所有子节点，为最后一个节点打上标记
        /// </summary>
        /// <param name="parentId"></param>
        void ResetLastNodeAttr(int parentId)
        {
            _nodeRepository.RetsetLastNodeAttr(parentId);

            var last = _nodeRepository.GetAll()
                                       .Where(x => x.ParentId == parentId)
                                       .OrderByDescending(x => x.Taxis)
                                       .FirstOrDefault();
            if (last != null)
            {
                last.IsLastNode = 1;
                Update(last);
            }
        }
        #endregion

    }
}
