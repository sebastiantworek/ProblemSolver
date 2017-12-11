using System;
using Game15;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemSolver;
using ProblemSolver.Data;

namespace ProblemSolverTest
{
    [TestClass]
    public class Game15ProblemTest
    {
        [TestMethod]
        public void RandomTest()
        {
            var board = new Board();
            board.InitRandom();

            var goal = new Board();
            goal.Init();

            Game15Problem problem = new Game15Problem();
            ProblemSolver<Board, SimpleTransition> problemSolver = new ProblemSolver<Board, SimpleTransition>(board, goal, problem);
            var solution = problemSolver.Solve();
            var statistics = problemSolver.Statistics;
        }
    }
}
