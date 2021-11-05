using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    internal interface IList : IAddRemoveCollection
    {
        public int Used { get; }
    }
}