using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C5;

namespace Algorithms.DataStructures.Heaps
{
    public class C5HeapWrapper<TItem> : IHeap<TItem>
    {
        protected readonly C5.IntervalHeap<TItem> _intervalHeap;
        public C5HeapWrapper(C5.IntervalHeap<TItem> intervalHeap)
        {
            _intervalHeap = intervalHeap;
        }

        public bool IsEmpty => _intervalHeap.IsEmpty;

        public object Add(TItem element)
        {
            IPriorityQueueHandle<TItem> handle = null;
            _intervalHeap.Add(ref handle, element);
            return handle;
        }

        public object Add(ref object handle, TItem element)
        {
            var typedHandle = handle as IPriorityQueueHandle<TItem>;

            if (handle != null && typedHandle == null)
                throw new InvalidPriorityQueueHandleException();

            _intervalHeap.Add(ref typedHandle, element);

            handle = typedHandle;

            return typedHandle;
        }

        public void Delete(object handle)
        {
            var typedHandle = handle as IPriorityQueueHandle<TItem>;

            if (typedHandle == null)
                throw new InvalidPriorityQueueHandleException();

            _intervalHeap.Delete(typedHandle);
        }

        public TItem FindMin(out object handle)
        {
            TItem item = _intervalHeap.FindMin(out IPriorityQueueHandle<TItem> typedHandle);
            handle = typedHandle;
            return item;
        }

        public TItem Get(object handle)
        {
            var typedHandle = handle as IPriorityQueueHandle<TItem>;

            if (typedHandle == null)
                throw new InvalidPriorityQueueHandleException();

            TItem element;
            if (!_intervalHeap.Find(typedHandle, out element))
                throw new IndexOutOfRangeException();

            return element;
        }

        public void Replace(object handle, TItem item)
        {
            var typedHandle = handle as IPriorityQueueHandle<TItem>;

            if (typedHandle == null)
                throw new InvalidPriorityQueueHandleException();

            _intervalHeap.Replace(typedHandle, item);
        }
    }
}
