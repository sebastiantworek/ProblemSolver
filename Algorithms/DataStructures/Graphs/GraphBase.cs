using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public abstract class GraphBase<TNode, TEdgeTag, TNodeInfo> : IGraph<TNode, TEdgeTag> where TNodeInfo : NodeInfo<TNode, TEdgeTag>
    {
        protected readonly Dictionary<TNode, TNodeInfo> _nodes = new Dictionary<TNode, TNodeInfo>();

        /// <summary>
        /// Method adds node to the graph if it does not alraedy exist.
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(TNode node)
        {
            if (_nodes.ContainsKey(node))
                return;

            _nodes[node] = (TNodeInfo)Activator.CreateInstance(typeof(TNodeInfo), new object[] { node });
        }

        public void AddNodes(params TNode[] nodes)
        {
            foreach (var node in nodes)
                AddNode(node);
        }

        public bool ContainsNode(TNode node)
        {
            return _nodes.ContainsKey(node);
        }

        public IEnumerable<EdgeInfo<TNode, TEdgeTag>> GetNeighbours(TNode node)
        {
            if (!ContainsNode(node))
                throw new ArgumentException("Graph does not contain given node");

            var nodeInfo = GetNodeInfo(node);
            return nodeInfo.Neighbours;
        }

     
        protected virtual TNodeInfo GetNodeInfo(TNode node)
        {
            TNodeInfo nodeInfo = _nodes[node];
            return nodeInfo;
        }
    }
}
