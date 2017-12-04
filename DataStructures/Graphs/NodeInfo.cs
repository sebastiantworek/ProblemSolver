using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class NodeInfo<TNode, TEdgeTag>
{
        public NodeInfo(TNode node)
        {
            Node = node;
        }

        private readonly Dictionary<TNode, TEdgeTag> _neighbours = new Dictionary<TNode, TEdgeTag>();

        public IEnumerable<(TEdgeTag edgeTag, TNode node)> Neighbours => _neighbours.Select(kvp => (edgeTag: kvp.Value, node: kvp.Key));

        private TNode Node { get; }

        public bool IsLoaded { get; private set; } = false;

        /// <summary>
        /// Method adds neigbour to the node. If the nodes are already neighbours then edgeTag will be override.
        /// </summary>
        /// <param name="edgeTag"></param>
        /// <param name="node"></param>
        private void AddNeigbour(TEdgeTag edgeTag, TNode node)
        {
            _neighbours[node] = edgeTag;
        }

        public void LoadNeighbours(INeighboursGetter<TNode, TEdgeTag> neighboursCallback)
        {
            foreach (var kvp in neighboursCallback.GetNeighbours(Node))
            {
                AddNeigbour(kvp.edgeTag, kvp.node);
            }
            IsLoaded = true;
        }
    }
}
