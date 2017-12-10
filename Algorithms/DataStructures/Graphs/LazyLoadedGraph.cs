using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures.Graphs
{
    /// <summary>
    /// This class respresents a graph which nodes will be lazy loaded. This allows to define also infinite graphs (but at the end only finit number of nodes will be loaded by certain algorithms).
    /// Node information provider (INodeLoader) has to be provided in constructor. Initial set of nodes has to be explicit added to the graph with the Add method. 
    /// Other nodes will be implicit loaded and added to the graph when an operation will be performed on one of their's neighbour.
    /// Example: GetNeighbours(node) will load node and add it's neighbours to the graph. 
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    /// <typeparam name="TEdgeTag"></typeparam>
    public class LazyLoadedGraph<TNode, TEdgeTag> : GraphBase<TNode, TEdgeTag, LazyLoadedNodeInfo<TNode, TEdgeTag>>
    {
        private readonly INodeLoader<TNode, TEdgeTag> _nodeLoader;

        public LazyLoadedGraph(INodeLoader<TNode, TEdgeTag> nodeLoader)
        {
            _nodeLoader = nodeLoader;
        }

        /// <summary>
        /// This method ovverides base getter to initializes node info for given node (if not initialized already). It calulates also list of neighbours of given node and adds them to the graph if necessary
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override LazyLoadedNodeInfo<TNode, TEdgeTag> GetNodeInfo(TNode node)
        {
            LazyLoadedNodeInfo<TNode, TEdgeTag> nodeInfo = _nodes[node];

            if (!nodeInfo.IsLoaded)
            {
                foreach (var kvp in _nodeLoader.GetNeighbours(node))
                {
                    if (!ContainsNode(kvp.Node))
                        AddNode(kvp.Node);

                    nodeInfo.AddNeigbour(kvp.EdgeTag, kvp.Node);
                }
            }

            return nodeInfo;
        }
    }
}
