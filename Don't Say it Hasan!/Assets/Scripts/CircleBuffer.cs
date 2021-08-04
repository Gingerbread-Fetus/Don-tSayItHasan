using System.Collections.Generic;

namespace Utility
{
    class CircleBuffer<T>
    {
        LinkedList<T> linkedList;

        public CircleBuffer()
        {
            linkedList = new LinkedList<T>();
        }

        public CircleBuffer(T[] objectArray)
        {
            linkedList = new LinkedList<T>(objectArray);
        }

        public void AddNew(T newElement)
        {
            linkedList.AddLast(newElement);
        }

        public T MoveNext()
        {
            T front = linkedList.First.Value;
            linkedList.RemoveFirst();
            linkedList.AddLast(front);
            return front;
        }

        public T MoveBack()
        {
            T back = linkedList.Last.Value;
            linkedList.RemoveLast();
            linkedList.AddFirst(back);
            return back;
        }
    }
}