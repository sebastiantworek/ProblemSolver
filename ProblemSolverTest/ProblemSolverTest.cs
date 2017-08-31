using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemSolver;
using System.Collections.Generic;

namespace ProblemSolverTest
{
    /// <summary>
    /// This test class use a list of integers from 1 to 10 as space of states. Initial state nad goal are one of them. Allowed moves are either one to right or one to left.
    /// </summary>
    [TestClass]
    public class IntListProblemTest
    {
        class IntTransitionData : ProblemSolver.Data.ITransition
        {
            public IntTransitionData(double cost)
            {
                Cost = cost;
            }

            public double Cost { get; }
        }

        List<Tuple<IntTransitionData, int>> GetTransition(int state)
        {
            var result = new List<Tuple<IntTransitionData, int>> ();
            if (state > 0)
                result.Add(new Tuple<IntTransitionData, int>(new IntTransitionData(1), state - 1));
            if(state<10)
                result.Add(new Tuple<IntTransitionData, int>(new IntTransitionData(1), state + 1));

            return result;
        }

        double HeuristicDistance(int state, int goal)
        {
            return Math.Abs(goal - state);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            ProblemSolver<int, IntTransitionData> problemSolver = new ProblemSolver<int, IntTransitionData>(5, 8, GetTransition, HeuristicDistance);
        }
    }
}
