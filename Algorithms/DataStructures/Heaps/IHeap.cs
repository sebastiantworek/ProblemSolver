using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Heaps
{
    public interface IHeap<TElement, THandle>
    {
        TElement FindMin(out THandle handle);

        THandle Add(TElement element);

        void Delete(THandle handle);

        void Replace(THandle handle, TElement element);

        TElement Get(THandle handle);
    }
}
