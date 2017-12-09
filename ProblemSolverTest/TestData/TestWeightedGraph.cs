using Algorithms.DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolverTest.TestData
{
    class WeightedNodeLoader : INodeLoader<int, SimpleWeightedEdge>
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public WeightedNodeLoader(int min, int max)
        {
            Min = min;
            Max = max;
        }


        public IEnumerable<(SimpleWeightedEdge edgeTag, int node)> GetNeighbours(int node)
        {
            if (node > Min)
                yield return (edgeTag: new SimpleWeightedEdge() { Cost = 1 }, node: node - 1);

            if (node < Max)
                yield return (edgeTag: new SimpleWeightedEdge() { Cost = 1 }, node: node + 1);
        }
    }

    public class TestWeightedGraph : LazyLoadedGraph<int, SimpleWeightedEdge>
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public TestWeightedGraph(int min, int max) : base(new WeightedNodeLoader(min, max))
        {
            Min = min;
            Max = max;
        }
    }
}
