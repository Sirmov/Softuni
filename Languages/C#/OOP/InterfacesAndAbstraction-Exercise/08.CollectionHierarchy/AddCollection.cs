using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    internal class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            Collection = new List<string>();
        }

        public IList<string> Collection { get; set; }

        public virtual int Add(string element)
        {
            Collection.Add(element);
            return Collection.Count - 1;
        }
    }
}