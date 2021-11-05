using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    internal interface IAddCollection
    {
        public IList<string> Collection { get; set; }

        public int Add(string element);
    }
}