using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public class NodeInfo<TNode, TEdgeTag>
    {
        public NodeInfo(TNode node)
        {
            Node = node;
        }

        protected readonly Dictionary<TNode, TEdgeTag> _neighbours = new Dictionary<TNode, TEdgeTag>();

        public IEnumerable<EdgeInfo<TNode, TEdgeTag>> Neighbours => _neighbours.Select(kvp => new EdgeInfo<TNode, TEdgeTag>() { EdgeTag = kvp.Value, Node = kvp.Key });

        protected TNode Node { get; }
        
        /// <summary>
        /// Method adds neigbour to the node. If the nodes are already neighbours then edgeTag will be override.
        /// </summary>
        /// <param name="edgeTag"></param>
        /// <param name="node"></param>
        public void AddNeigbour(TEdgeTag edgeTag, TNode node)
        {
            _neighbours[node] = edgeTag;
        }
    }
}
