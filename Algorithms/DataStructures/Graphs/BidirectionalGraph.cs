using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public class BidirectionalGraph<TNode, TEdgeTag> : GraphBase<TNode, TEdgeTag, NodeInfo<TNode, TEdgeTag>>
    {
        public void AddEdge(TNode first, TNode second, TEdgeTag edgeTag)
        {
            var firstInfo = GetNodeInfo(first);
            var secondInfo = GetNodeInfo(second);

            firstInfo.AddNeigbour(edgeTag, second);
            secondInfo.AddNeigbour(edgeTag, first);
        }
    }
}
