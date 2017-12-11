using Algorithms.DataStructures.Graphs;
using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
    public class AStar<TNode, TEdgeTag> where TEdgeTag : IWeightedEdge
    {
        #region Members

        private readonly IGraph<TNode, TEdgeTag> _graph;
        private readonly Func<TNode, TNode, double> _heuristicDistance;
        private TNode _targetNode;

        private Dictionary<TNode, NodeTag> _nodeTags;
        private C5.IntervalHeap<TNode> _openNodes;

        #endregion

        #region Constructor

        public AStar(IGraph<TNode, TEdgeTag> graph, Func<TNode, TNode, double> heuristicDistance)
        {
            _graph = graph;
            _heuristicDistance = heuristicDistance;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns path (edges information) from source to the target
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public List<TNode> Compute(TNode source, TNode target)
        {
            _targetNode = target;

            ResetBuffers();

            OpenNode(source, 0, source);

            while (!_openNodes.IsEmpty)
            {
                TNode minimalNode = _openNodes.FindMin(out var minimalNodeHandle);
                
                if (minimalNode.Equals(_targetNode))
                    return ConstructPath(_targetNode);
                
                var minimalNodeTag = LoadNodeTag(minimalNode);
                CloseNode(minimalNode);

                var neighbours = _graph.GetNeighbours(minimalNode);
                foreach (var edgeInfo in neighbours)
                {
                    TNode neighbour = edgeInfo.Node;
                    NodeTag neigbourTag = LoadNodeTag(neighbour);
                    double actualDistance = minimalNodeTag.ActualDistance + edgeInfo.EdgeTag.Cost;

                    switch (neigbourTag.State)
                    {
                        case NodeTagState.Closed:
                            continue;
                        case NodeTagState.New:
                            OpenNode(neighbour, actualDistance, minimalNode);
                            break;
                        case NodeTagState.Open:
                            if (actualDistance >= neigbourTag.ActualDistance)
                                continue;
                            OpenNode(neighbour, actualDistance, minimalNode);
                            break;
                    }
                }
            }

            return null;
        }

        private List<TNode> ConstructPath(TNode target)
        {
            var result = new List<TNode>();
            result.Add(target);

            NodeTag nodeTag = LoadNodeTag(target);
            while(nodeTag.Predecessor != null)
            {
                result.Insert(0, nodeTag.Predecessor);

                var oldPredecessor = nodeTag.Predecessor;
                nodeTag = LoadNodeTag(nodeTag.Predecessor);

                if (oldPredecessor.Equals( nodeTag.Predecessor))
                    break;
            }

            return result;
        }

        private void ResetBuffers()
        {
            _nodeTags = new Dictionary<TNode, NodeTag>();
            _openNodes = new C5.IntervalHeap<TNode>(new DistanceComparer(_nodeTags));
        }
        
        private NodeTag LoadNodeTag(TNode node)
        {
            if (!_nodeTags.ContainsKey(node))
                _nodeTags[node] = new NodeTag(_heuristicDistance(node, _targetNode));

            return _nodeTags[node];
        }

        /// <summary>
        /// Method marks given node as approached by predecessor with given actual distance. Status of the node will be changed to open. It will be also either added to _openQueue or updated in it
        /// </summary>
        /// <param name="node"></param>
        /// <param name="acutalDistance"></param>
        /// <param name="predecessor"></param>
        private void OpenNode(TNode node, double acutalDistance, TNode predecessor)
        {
            var nodeTag = LoadNodeTag(node);

            nodeTag.State = NodeTagState.Open;
            nodeTag.ActualDistance = acutalDistance;
            nodeTag.Predecessor = predecessor;
            C5.IPriorityQueueHandle<TNode> handle = nodeTag.Handle;
            if (handle == null)
                _openNodes.Add(ref handle, node);
            else
                _openNodes.Replace(handle, node);
            
            nodeTag.Handle = handle;
        }

        private void CloseNode(TNode node)
        {
            var nodeTag = LoadNodeTag(node);
            nodeTag.State = NodeTagState.Closed;
            _openNodes.Delete(nodeTag.Handle);

            ENodeClosed?.Invoke(node);
        }

        public Action<TNode> ENodeClosed;

        #endregion

        #region Internal types

        class NodeTag
        {
            public NodeTag(double heuristicDistance)
            {
                HeuristicDistance = heuristicDistance;
            }

            public double ActualDistance { get; set; }
            public double HeuristicDistance { get; }
            public TNode Predecessor { get; set; }
            public NodeTagState State { get; set; } = NodeTagState.New;
            public C5.IPriorityQueueHandle<TNode> Handle { get;set;}
        }

        enum NodeTagState { New, Open, Closed }

        class DistanceComparer : IComparer<TNode>
        {
            private readonly Dictionary<TNode, NodeTag> _nodeTags = new Dictionary<TNode, NodeTag>();

            public DistanceComparer(Dictionary<TNode, NodeTag> nodeTags)
            {
                _nodeTags = nodeTags;
            }

            public int Compare(TNode first, TNode second)
            {
                var firstTag = _nodeTags[first];
                var secondTag = _nodeTags[second];

                double firstScore = firstTag.ActualDistance + firstTag.HeuristicDistance;
                double secondScore = secondTag.ActualDistance + secondTag.HeuristicDistance;

                return firstScore.CompareTo(secondScore);
            }
        }

        #endregion
    }
}
