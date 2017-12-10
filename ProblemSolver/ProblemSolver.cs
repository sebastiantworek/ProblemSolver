using Algorithms.DataStructures.Graphs;
using Algorithms.Algorithms;
using ProblemSolver.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProblemSolver
{
    public class ProblemSolver<TState, TTransition> where TTransition : ITransition
    {
        private readonly LazyLoadedGraph<TState, TTransition> _graph;

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

            _graph = new LazyLoadedGraph<TState, TTransition>(new ProblemNodeLoader(problem));
            _graph.AddNode(initialNode);
        }

        #endregion

        #region

        public IEnumerable<TState> Solve()
        {
            var astar = new AStar<TState, TTransition>(_graph, Problem.GetHeuristicDistance);
            return astar.Compute(InitialNode,Goal);
        }

        #endregion

        #region Properties

        public TState InitialNode { get; }

        public TState Goal { get; }

        public IProblem<TState, TTransition> Problem { get; }

        #endregion

        class ProblemNodeLoader : INodeLoader<TState, TTransition>
        {
            IProblem<TState, TTransition> _problem;

            public ProblemNodeLoader(IProblem<TState, TTransition> problem)
            {
                _problem = problem;
            }
            public IEnumerable<EdgeInfo<TState, TTransition>> GetNeighbours(TState node)
            {
                return _problem.GetTransitions(node).Select(o => new EdgeInfo<TState, TTransition>() { Node = o.Item2, EdgeTag = o.Item1 });
            }
        }
    }
}
