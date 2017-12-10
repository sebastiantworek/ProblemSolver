using ProblemSolver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game15
{
    public class Game15Problem : IProblem<Board, SimpleTransition>
    {
        public double GetHeuristicDistance(Board state, Board goal)
        {
            int difference = 0;
            for (int i = 0; i < Board.Width; i++)
            {
                for (int j = 0; j < Board.Heigh; j++)
                {
                    int field = state[i, j];
                    var position = goal.FindPostion(field);
                    difference += Math.Abs(i - position.x);
                    difference += Math.Abs(j - position.y);
                }
            }
            return difference;
        }

        public IEnumerable<Tuple<SimpleTransition, Board>> GetTransitions(Board state)
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var clone = state.Clone();
                if(clone.Move(direction))
                    yield return new Tuple<SimpleTransition, Board>(new SimpleTransition(1), clone);
            }

        }
    }
}
