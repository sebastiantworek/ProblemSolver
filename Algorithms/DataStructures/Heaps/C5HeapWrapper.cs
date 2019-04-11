using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C5;

namespace Algorithms.DataStructures.Heaps
{
    public class C5HeapWrapper<TItem> : IHeap<TItem, C5.IPriorityQueueHandle<TItem>>
    {
        protected readonly C5.IntervalHeap<TItem> _intervalHeap;
        public C5HeapWrapper(IComparer<TItem> comparer)
        {
            _intervalHeap = new IntervalHeap<TItem>(comparer);
        }

        public IPriorityQueueHandle<TItem> Add(TItem element)
        {
            IPriorityQueueHandle<TItem> handle = null;
            _intervalHeap.Add(ref handle, element);
            return handle;
        }

        public void Delete(IPriorityQueueHandle<TItem> handle)
        {
            _intervalHeap.Delete(handle);
        }

        public TItem FindMin(out IPriorityQueueHandle<TItem> handle)
        {
            return _intervalHeap.FindMin(out handle);
        }

        public TItem Get(IPriorityQueueHandle<TItem> handle)
        {
            TItem element;
            if (!_intervalHeap.Find(handle, out element))
                throw new IndexOutOfRangeException();
            return element;
        }

        public void Replace(IPriorityQueueHandle<TItem> handle, TItem item)
        {
            _intervalHeap.Replace(handle, item);
        }
    }
}
