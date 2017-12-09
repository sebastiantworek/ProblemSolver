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

        [TestMethod]
        public void TwoPathTest()
        {   /*
            A-B-C-D
            E     F
            G-H-I-J
            */
            var graph = new BidirectionalGraph<string,SimpleWeightedEdge>();
            graph.AddNodes("A", "B", "C", "D", "E", "F", "G", "H", "I","J");
            graph.AddEdge("A", "B", new SimpleWeightedEdge(1));
            graph.AddEdge("B", "C", new SimpleWeightedEdge(1));
            graph.AddEdge("C", "D", new SimpleWeightedEdge(1));
            graph.AddEdge("A", "E", new SimpleWeightedEdge(1));
            graph.AddEdge("E", "G", new SimpleWeightedEdge(1));
            graph.AddEdge("D", "F", new SimpleWeightedEdge(1));
            graph.AddEdge("F", "J", new SimpleWeightedEdge(1));
            graph.AddEdge("G", "H", new SimpleWeightedEdge(1));
            graph.AddEdge("H", "I", new SimpleWeightedEdge(1));
            graph.AddEdge("J", "I", new SimpleWeightedEdge(1));

            var algorithm = new AStar<string, SimpleWeightedEdge>(graph, (u, v) => 1);
            var result = algorithm.Compute("B", "H").ToList();

            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("B", result[0]);
            Assert.AreEqual("A", result[1]);
            Assert.AreEqual("E", result[2]);
            Assert.AreEqual("G", result[3]);
            Assert.AreEqual("H", result[4]);
        }
    }
}
