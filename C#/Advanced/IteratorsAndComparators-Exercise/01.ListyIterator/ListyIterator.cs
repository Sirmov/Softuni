using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ListyIterator
{
    class ListyIterator<T>
    {
        private List<T> collection;

        private int index;

        public ListyIterator(params T[] collection)
        {
            this.collection = collection.ToList();
            index = 0;
        }

        public bool Move()
        {
            if (index == collection.Count - 1)
            {
                return false;
            }
            else
            {
                index++;
                return true;
            }
        }

        public bool HasNext() => index < collection.Count - 1;

        public void Print()
        {
            if (collection.Count < 1)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(collection[index]);
            }
        }
    }
}
