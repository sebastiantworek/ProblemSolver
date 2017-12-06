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
    

        public IEnumerable<(int edgeTag, int node)> GetNeighbours(int node)
        {
            if (node > Min)
                yield return (edgeTag: 1, node: node - 1);

            if (node < Max)
                yield return (edgeTag: 1, node: node  + 1);
        }
    }

    public class TestIntGraph : VirtualGraph<int,int>
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public TestIntGraph(int min,int max) : base(new IntNodeLoader(min,max))
        {
            Min = min;
            Max = max;
        }
    }
}
