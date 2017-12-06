using System;
using System.Linq;
using Algorithms.DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemSolverTest.TestData;

namespace ProblemSolverTest
{
    [TestClass]
    public class VirtualGraphTests
    {
        [TestMethod]
        public void GetNodesTest()
        {
            var graph = new TestIntGraph(1, 10);

            graph.AddNode(1);
            var result = graph.GetNeighbours(1).ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, result[0].Node);
            Assert.AreEqual(1, result[0].EdgeTag);
            
            graph.AddNode(10);
            result = graph.GetNeighbours(10).ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(9, result[0].Node);
            Assert.AreEqual(1, result[0].EdgeTag);

            graph.AddNode(5);
            result = graph.GetNeighbours(5).ToList();
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(24, result[0].Node * result[1].Node); //4 and 6 expected
            Assert.AreEqual(10, result[0].Node + result[1].Node);
            Assert.AreEqual(1, result[0].EdgeTag);
        }

        [TestMethod]
        public void ContainsNodeTest()
        {
            var graph = new TestIntGraph(1, 10);

            Assert.IsFalse(graph.ContainsNode(1));
            Assert.IsFalse(graph.ContainsNode(10));

            graph.AddNode(1);

            Assert.IsTrue(graph.ContainsNode(1));
            Assert.IsFalse(graph.ContainsNode(2));
            
            //This call will load node '1' and add it's neighbours to the graph
            graph.GetNeighbours(1);

            Assert.IsTrue(graph.ContainsNode(1));
            Assert.IsTrue(graph.ContainsNode(2));
            Assert.IsFalse(graph.ContainsNode(3));
        }
    }
}
