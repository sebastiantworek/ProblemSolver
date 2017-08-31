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
        /// <param name="goalNode">Goal state</param>
        /// <param name="getTransitions">List of available transiton from a particular state</param>
        /// <param name="heuristic">Heuristic distance function between 2 state. It's value cannot be grater then real transition cost for any pair of states</param>
        public ProblemSolver(TState initialNode, TState goalNode, Func<TState, List<Tuple<TTransition, TState>>> getTransitions, Func<TState, TState, double> heuristic)
        {
            InitialNode = initialNode;
        }

        #endregion

        #region Properties

        public TState InitialNode { get; }

        #endregion
    }
}
