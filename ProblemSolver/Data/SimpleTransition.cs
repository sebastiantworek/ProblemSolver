using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolver.Data
{
    public class SimpleTransition : ITransition
    {
        public SimpleTransition(double cost)
        {
            Cost = cost;
        }

        public double Cost { get; private set; }
    }
}
