using ProblemSolver.Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace ProblemSolver
{
    public class ProblemSolver<TState, TTransition> where TTransition: ITransition
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialNode">Initial state of the problem</param>
        /// <param name="goal">Goal state</param>
        /// <param name="getTransitions">List of available transiton from a particular state</param>
        /// <param name="heuristic">Heuristic distance function between 2 state. It's value cannot be grater then real transition cost for any pair of states</param>
        public ProblemSolver(TState initialNode, TState goal, IProblem<TState, TTransition> problem)
        {
            InitialNode = initialNode;
            Goal = goal;
            Problem = problem;
        }

        #endregion

        #region

        private double GetHeuristicCost(TState state) => Problem.GetHeuristicDistance(state, Goal);

        #endregion

        #region Properties

        public TState InitialNode { get; }

        public TState Goal { get; }

        public IProblem<TState, TTransition> Problem { get; }

        #endregion
    }
}
