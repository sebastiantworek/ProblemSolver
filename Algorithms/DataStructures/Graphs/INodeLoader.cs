using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public interface INodeLoader<TNode, TEdgeTag>
    {
        IEnumerable<EdgeInfo<TNode,TEdgeTag>> GetNeighbours(TNode node);
    }
}
