using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static int DateDifference(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            return Math.Abs((first - second).Days);
        }
    }
}
