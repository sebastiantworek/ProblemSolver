using Algorithms.DataStructures.Graphs;
using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
    public class AStar<TNode, TEdgeTag> where TEdgeTag : IWeightedEdge
    {
        private readonly IGraph<TNode, TEdgeTag> _graph;
        private readonly Func<TNode, TNode, double> _heuristicDistance;
        private TNode _targetNode;

        private Dictionary<TNode, NodeTag> _nodeTags;
        private C5.IntervalHeap<TNode> _openNodes;
        private HashSet<TNode> _closedNodes;

        public AStar(IGraph<TNode, TEdgeTag> graph, Func<TNode, TNode, double> heuristicDistance)
        {
            _graph = graph;
            _heuristicDistance = heuristicDistance;
        }

        public IEnumerable<EdgeInfo<TNode, TEdgeTag>> Compute(TNode source, TNode target)
        {
            _targetNode = target;

            ResetBuffers();

            LoadNodeTag(source);
            _nodeTags[source].ActualDistance = 0;
            _openNodes.Add(source);

            while (!_openNodes.IsEmpty)
            {
                TNode minimalNode = _openNodes.FindMin(out var minimalNodeHandle);
                
                if (minimalNode.Equals(_targetNode))
                    return ConstructPath();

                _openNodes.Delete(minimalNodeHandle);
                _closedNodes.Add(minimalNode);
            }
        }

        private IEnumerable<EdgeInfo<TNode, TEdgeTag>> ConstructPath()
        {
            return null;
        }

        private void ResetBuffers()
        {
            _nodeTags = new Dictionary<TNode, NodeTag>();
            _openNodes = new C5.IntervalHeap<TNode>(new DistanceComparer(_nodeTags));
            _closedNodes = new HashSet<TNode>();
        }


        private void LoadNodeTag(TNode node)
        {
            if (!_nodeTags.ContainsKey(node))
                _nodeTags[node] = new NodeTag(_heuristicDistance(node, _targetNode));
        }

        class NodeTag
        {
            public NodeTag(double heuristicDistance)
            {
                HeuristicDistance = heuristicDistance;
            }

            public double ActualDistance { get; set; }
            public double HeuristicDistance { get; }
            public TNode Predecessor { get; set; }
        }

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
    }
}
