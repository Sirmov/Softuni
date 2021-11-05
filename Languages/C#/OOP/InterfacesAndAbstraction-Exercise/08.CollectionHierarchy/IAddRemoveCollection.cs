using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    internal interface IAddRemoveCollection : IAddCollection
    {
        public string Remove();
    }
}