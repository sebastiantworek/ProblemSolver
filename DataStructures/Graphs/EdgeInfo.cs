using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class EdgeInfo<TNode, TEdgeTag>
    {
        TNode Node { get; set; }
        TEdgeTag EdgeTag { get; set; }
    }
}
