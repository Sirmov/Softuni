using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    internal class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public override int Add(string element)
        {
            Collection.Insert(0, element);
            return 0;
        }

        public virtual string Remove()
        {
            string element = Collection[Collection.Count - 1];
            Collection.RemoveAt(Collection.Count - 1);
            return element;
        }
    }
}