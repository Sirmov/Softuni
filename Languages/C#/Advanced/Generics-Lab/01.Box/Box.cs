using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> box = new Stack<T>();

        public int Count => box.Count;

        public void Add(T element)
        {
            box.Push(element);
        }

        public T Remove() => box.Pop();
    }
}
