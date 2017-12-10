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
        public void IdentityTest()
        {
            var board = new Board();
            board.Init();

            var goal = board.Clone();

            Assert.IsTrue(board.Move(Direction.Right));
            Assert.IsTrue(board.Move(Direction.Right));

            Game15Problem problem = new Game15Problem();
            ProblemSolver<Board, SimpleTransition> problemSolver = new ProblemSolver<Board, SimpleTransition>(board, goal, problem);
            var xx = problemSolver.Solve();
        }
    }
}
