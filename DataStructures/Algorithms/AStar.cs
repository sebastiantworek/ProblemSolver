using Algorithms.DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algorithms
{
    public class AStar<TNode,TEdgeTag> where TEdgeTag: IWeightedEdge
    {
        private readonly IGraph<TNode, TEdgeTag> _graph;
        private readonly Func<TNode, TNode, double> _heuristicDistance;
        

        public AStar(IGraph<TNode,TEdgeTag> graph, Func<TNode,TNode,double> heuristicDistance)
        {
            _graph = graph;
            _heuristicDistance = heuristicDistance;
        }

        public void Solve(TNode source, TNode target)
        {
            ResetBuffers();
        }

        private void ResetBuffers()
        {
            throw new NotImplementedException();
        }
    }
}
