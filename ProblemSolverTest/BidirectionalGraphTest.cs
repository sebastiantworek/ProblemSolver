using System;
using System.Linq;
using Algorithms.DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProblemSolverTest
{
    [TestClass]
    public class BidirectionalGraphTest
    {
        [TestMethod]
        public void GetNodesTest()
        {
            // Graph [10]--A--[20]--B--[30]
            BidirectionalGraph<int, string> graph = new BidirectionalGraph<int, string>();
            graph.AddNode(10);
            graph.AddNode(20);
            graph.AddNode(30);
            graph.AddEdge(10, 20, "A");
            graph.AddEdge(20, 30, "B");

            var neighbours = graph.GetNeighbours(10).ToList();
            Assert.AreEqual(1, neighbours.Count);
            Assert.AreEqual(20, neighbours[0].Node);
            Assert.AreEqual("A", neighbours[0].EdgeTag);

            neighbours = graph.GetNeighbours(20).OrderBy(x => x.EdgeTag).ToList();
            Assert.AreEqual(2, neighbours.Count);
            Assert.AreEqual(10, neighbours[0].Node);
            Assert.AreEqual("A", neighbours[0].EdgeTag);
            Assert.AreEqual(30, neighbours[1].Node);
            Assert.AreEqual("B", neighbours[1].EdgeTag);
        }
    }
}
