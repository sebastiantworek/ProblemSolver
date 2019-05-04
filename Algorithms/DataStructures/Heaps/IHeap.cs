using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Heaps
{
    public interface IHeap<TElement>
    {
        TElement FindMin(out object handle);

        /// <summary>
        /// Adds element to the heap and return its handle
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Handle to the added element</returns>
        object Add(TElement element);

        object Add(ref object handle, TElement element);

        void Delete(object handle);

        void Replace(object handle, TElement element);

        TElement Get(object handle);

        bool IsEmpty { get; }
    }
}
