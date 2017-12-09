using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public class LazyLoadedNodeInfo<TNode, TEdgeTag> : NodeInfo<TNode, TEdgeTag>
    {
        public LazyLoadedNodeInfo(TNode node) : base(node)
        {

        }

        public bool IsLoaded { get; set; } = false;
    }
}
