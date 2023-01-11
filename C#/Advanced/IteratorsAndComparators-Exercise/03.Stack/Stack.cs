using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;

        private int index;

        public Stack(params T[] elements)
        {
            collection = elements.ToList();
            index = collection.Count - 1;
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                collection.Add(element);
                index++;
            }
        }

        public T Pop()
        {
            if (collection.Count > 0)
            {
                T element = collection[index--];
                collection.RemoveAt(collection.Count - 1);
                return element;
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
