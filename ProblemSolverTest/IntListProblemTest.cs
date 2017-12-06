using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemSolver;
using System.Collections.Generic;
using ProblemSolverTest.TestData;

namespace ProblemSolverTest
{
    /// <summary>
    /// This test class use a list of integers from 1 to 10 as space of states. Initial state nad goal are one of them. Allowed moves are either one to right or one to left.
    /// </summary>
    [TestClass]
    public class IntListProblemTest
    {                      
        [TestMethod]
        public void ConstructorTest()
        {
            ProblemSolver<int, IntTransitionData> problemSolver = new ProblemSolver<int, IntTransitionData>(5, 8, new IntListProblem());
        }
    }
}
