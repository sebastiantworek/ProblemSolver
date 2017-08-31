using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolver.Data
{
    public interface IProblem<TState,TTransition> where TTransition:ITransition
    {
    }
}
