using System;
using System.Linq;
using Algorithms.Algorithms;
using Algorithms.DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemSolverTest.TestData;

namespace ProblemSolverTest
{
    [TestClass]
    public class AStartTest
    {
        [TestMethod]
        public void IntGraphTest()
        {
            TestWeightedGraph graph = new TestWeightedGraph(1, 10);
            graph.AddNode(1);
            var algorithm = new AStar<int, SimpleWeightedEdge>(graph, (u, v) => 1);
            var xx = algorithm.Compute(1,10).ToList();
        }
    }
}
