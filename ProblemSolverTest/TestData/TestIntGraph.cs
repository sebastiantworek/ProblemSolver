using Algorithms.DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolverTest.TestData
{
    class IntNodeLoader : INodeLoader<int, int>
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public IntNodeLoader(int min, int max)
        {
            Min = min;
            Max = max;
        }


        public IEnumerable<EdgeInfo<int, int>> GetNeighbours(int node)
        {
            if (node > Min)
                yield return new EdgeInfo<int, int> { EdgeTag = 1, Node = node - 1 };

            if (node < Max)
                yield return new EdgeInfo<int, int> { EdgeTag = 1, Node = node + 1 };
        }

        IEnumerable<EdgeInfo<int, int>> INodeLoader<int, int>.GetNeighbours(int node)
        {
            throw new NotImplementedException();
        }
    }

    public class TestIntGraph : LazyLoadedGraph<int, int>
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public TestIntGraph(int min, int max) : base(new IntNodeLoader(min, max))
        {
            Min = min;
            Max = max;
        }
    }
}
