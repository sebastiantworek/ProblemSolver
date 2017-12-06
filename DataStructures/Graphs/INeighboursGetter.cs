using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public interface INodeLoader<TNode, TEdgeTag>
    {
        IEnumerable<(TEdgeTag edgeTag, TNode node)> GetNeighbours(TNode node);
    }
}
