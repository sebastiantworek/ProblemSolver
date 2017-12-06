using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    /// <summary>
    /// This class respresents a graph which nodes will be lazy loaded. This allows to define also infinite graphs (but at the end only finit number of nodes will be loaded by certain algorithms).
    /// Node information provider (INodeLoader) has to be provided in constructor. Initial set of nodes has to be explicit added to the graph with the Add method. 
    /// Other nodes will be implicit loaded and added to the graph when an operation will be performed on one of their's neighbour.
    /// Example: GetNeighbours(node) will load node and add it's neighbours to the graph. 
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    /// <typeparam name="TEdgeTag"></typeparam>
    public class VirtualGraph<TNode, TEdgeTag> : IGraph<TNode, TEdgeTag>
    {
        private readonly INodeLoader<TNode, TEdgeTag> _nodeLoader;

        private readonly Dictionary<TNode, NodeInfo<TNode,TEdgeTag>> _nodes = new Dictionary<TNode, NodeInfo<TNode, TEdgeTag>>();

        public VirtualGraph(INodeLoader<TNode, TEdgeTag> nodeLoader)
        {
            _nodeLoader = nodeLoader;
        }

        /// <summary>
        /// Method adds node to the graph if it does not alraedy exist. When a node will be loaded then it's neigbours will be calculated and added to the graph, but at least one initial node has to be added to the graph with this method.
        /// This initial node will serve later as a root for further loading.
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

        /// <summary>
        /// This method loads given node and return it's neighbours
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<(TEdgeTag edgeTag, TNode node)> GetNeighbours(TNode node)
        {
            if (!ContainsNode(node))
                throw new ArgumentException("Graph does not contain given node");

            NodeInfo<TNode, TEdgeTag> nodeInfo = LoadNode(node);
            
            return nodeInfo.Neighbours;
        }

        /// <summary>
        /// This method initializes node info for given node (if not initialized already). It calulates also list of neighbours of given node and adds them to the graph if necessary
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private NodeInfo<TNode, TEdgeTag> LoadNode(TNode node)
        {
            NodeInfo<TNode, TEdgeTag> nodeInfo = _nodes[node];

            if (!nodeInfo.IsLoaded)
            {
                foreach (var kvp in _nodeLoader.GetNeighbours(node))
                {
                    if (!ContainsNode(kvp.node))
                        AddNode(kvp.node);

                    nodeInfo.AddNeigbour(kvp.edgeTag, kvp.node);
                }
            }

            return nodeInfo;
        }
    }
}
