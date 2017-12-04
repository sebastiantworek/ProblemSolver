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
            //var graph = new DelegateImplicitGraph<TState,QuickGraph.TaggedEquatableEdge>()
            //var graph = new QuickGraph.DelegateUndirectedGraph<TState, TaggedUndirectedEdge<TState, TTransition>>(new List<TState> { initialNode }, TryGetEdges, false);
            //var graph = new BidirectionalGraph<TState, TaggedEdge<TState, TTransition>>();
            var graph = new DelegateBidirectionalIncidenceGraph<TState, TaggedEquatableEdge<TState,TTransition>>(TryGetEdges, TryGetEdges);
            var algorithm = new QuickGraph.Algorithms.ShortestPath.AStarShortestPathAlgorithm<TState, TaggedEquatableEdge<TState,TTransition>>(graph, GetCost, GetHeuristicCost);
        }

        #endregion

        #region

        private bool TryGetEdges(TState state, out IEnumerable<TaggedEquatableEdge<TState, TTransition>> result)
        {
            throw new NotImplementedException();
            result = null;

            return true;
        }

        private double GetCost(TaggedEquatableEdge<TState,TTransition> edge)
        {
            throw new NotImplementedException();
        }

        private double GetHeuristicCost(TState state) => Problem.GetHeuristicDistance(state, Goal);

        #endregion

        #region Properties

        public TState InitialNode { get; }

        public TState Goal { get; }

        public IProblem<TState, TTransition> Problem { get; }

        #endregion
    }
}
