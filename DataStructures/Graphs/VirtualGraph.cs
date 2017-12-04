using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class VirtualGraph<TNode, TEdgeTag> : IGraph<TNode, TEdgeTag>
    {
        private readonly INeighboursGetter<TNode, TEdgeTag> _neighboursGetter;

        private readonly Dictionary<TNode, NodeInfo<TNode,TEdgeTag>> _nodes = new Dictionary<TNode, NodeInfo<TNode, TEdgeTag>>();

        public VirtualGraph(INeighboursGetter<TNode, TEdgeTag> getNeighboursCallback)
        {
            _neighboursGetter = getNeighboursCallback;
        }

        /// <summary>
        /// Method adds node to the graph if it does not alraedy exist.
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(TNode node)
        {
            if (_nodes.ContainsKey(node))
                return;

            var nodeInfo = new NodeInfo<TNode, TEdgeTag>(node);
            _nodes.Add(node, nodeInfo);
        }

        public bool ContainsNode(TNode node)
        {
            return _nodes.ContainsKey(node);
        }

        public IEnumerable<(TEdgeTag edgeTag, TNode node)> GetNeighbours(TNode node)
        {
            if (!ContainsNode(node))
                throw new ArgumentException("Graph does not contain given node");

            NodeInfo<TNode, TEdgeTag> nodeInfo = _nodes[node];
            if(!nodeInfo.IsLoaded)
            {
                nodeInfo.LoadNeighbours(_neighboursGetter);
            }

            return nodeInfo.Neighbours;
        }
    }
}
