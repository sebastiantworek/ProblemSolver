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

        [TestMethod]
        public void IdentityTest()
        {
            var board = new Board();
            board.Init();

            var goal = new Board();
            goal.Init();

            Game15Problem problem = new Game15Problem();
            ProblemSolver<Board, SimpleTransition> problemSolver = new ProblemSolver<Board, SimpleTransition>(board, goal, problem);
            var solution = problemSolver.Solve();
            Assert.AreEqual(1, solution.Count);
            Assert.AreEqual(goal, solution[0]);
        }

        [TestMethod]
        public void SimpleTest()
        {
            var goal = new Board();
            goal.Init();

            var board = goal.Clone();

            //Move blank twice to the right
            Assert.IsTrue(board.Move(Direction.Right));
            Assert.IsTrue(board.Move(Direction.Right));

            Game15Problem problem = new Game15Problem();
            ProblemSolver<Board, SimpleTransition> problemSolver = new ProblemSolver<Board, SimpleTransition>(board, goal, problem);
            var solution = problemSolver.Solve();
            Assert.AreEqual(3, solution.Count);
            Assert.AreEqual(board, solution[0]);

            var middleState = board.Clone();
            Assert.IsTrue(middleState.Move(Direction.Left));
            Assert.AreEqual(middleState, solution[1]);

            Assert.AreEqual(goal, solution[2]);
        }
    }
}
