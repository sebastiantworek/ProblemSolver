using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public interface IGraph<TNode,TEdgeTag>
    {
        void AddNode(TNode u);

        void AddEdge(TNode u, TNode v, TEdgeTag edge);

        IEnumerable<(TEdgeTag,TNode)> GetNeighbours(TNode u);
    }
}
