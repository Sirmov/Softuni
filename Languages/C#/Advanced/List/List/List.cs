using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class List<T>
    {
        private T[] collection;

        public List(int capacity = 2)
        {
            Capacity = capacity;
            collection = new T[Capacity];
            Count = -1;
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public void Add(T element)
        {
            Count++;

            if (Count >= Capacity)
            {
                Resize();
            }

            collection[Count] = element;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Index out of the bounds of the list.");
            }

            T element = collection[index];

            Shift(index);

            if (Count <= Capacity / 4)
            {
                Shrink();
            }

            return element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (collection[i].Equals(element))
                {
                    return true;
                }

            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex > Count ||
                secondIndex < 0 || secondIndex > Count)
            {
                throw new ArgumentOutOfRangeException("Index out of the bounds of the list.");
            }

            T temp = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temp;
        }

        private void Resize()
        {
            T[] resizedCollection = new T[Capacity * 2];

            for (int i = 0; i < collection.Length; i++)
            {
                resizedCollection[i] = collection[i];
            }

            Capacity *= 2;
            collection = resizedCollection;
        }

        private void Shrink()
        {
            T[] resizedCollection = new T[Capacity / 2];

            for (int i = 0; i < collection.Length; i++)
            {
                resizedCollection[i] = collection[i];
            }

            collection = resizedCollection;
        }

        private void Shift(int index)
        {
            for (int i = index + 1; i <= Count; i++)
            {
                collection[i - 1] = collection[i];
            }

            Count--;
        }
    }
}
