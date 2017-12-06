using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public class EdgeInfo<TNode, TEdgeTag>
    {
        public TNode Node { get; set; }
        public TEdgeTag EdgeTag { get; set; }
    }
}
