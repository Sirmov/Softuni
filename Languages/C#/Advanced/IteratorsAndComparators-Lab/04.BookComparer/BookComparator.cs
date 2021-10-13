using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            int retreval = x.Title.CompareTo(y.Title);

            if (retreval == 0)
            {
                retreval = y.Year.CompareTo(x.Year);
            }

            return retreval;
        }
    }
}
