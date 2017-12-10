using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolverTest.TestData
{
    public class IntTransitionData : ProblemSolver.Data.ITransition
    {
        public IntTransitionData(double cost)
        {
            Cost = cost;
        }

        public double Cost { get; }
    }

    public class IntListProblem : ProblemSolver.Data.IProblem<int, IntTransitionData>
    {
        public IEnumerable<Tuple<IntTransitionData, int>> GetTransitions(int state)
        {
            var result = new List<Tuple<IntTransitionData, int>>();
            if (state > 0)
                result.Add(new Tuple<IntTransitionData, int>(new IntTransitionData(1), state - 1));
            if (state < 10)
                result.Add(new Tuple<IntTransitionData, int>(new IntTransitionData(1), state + 1));

            return result;
        }

        public double GetHeuristicDistance(int state, int goal)
        {
            return Math.Abs(goal - state);
        }
    }
}
