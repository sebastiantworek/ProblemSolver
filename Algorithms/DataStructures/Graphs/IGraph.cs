using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Graphs
{
    public interface IGraph<TNode,TEdgeTag>
    {
        void AddNode(TNode u);     

        IEnumerable<EdgeInfo<TNode,TEdgeTag>> GetNeighbours(TNode node);

        bool ContainsNode(TNode node);
    }
}
