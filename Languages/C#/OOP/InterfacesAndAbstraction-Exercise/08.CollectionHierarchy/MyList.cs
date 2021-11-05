using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    internal class MyList : AddRemoveCollection, IList
    {
        public override string Remove()
        {
            string element = Collection[0];
            Collection.RemoveAt(0);
            return element;
        }

        public int Used => Collection.Count;
    }
}