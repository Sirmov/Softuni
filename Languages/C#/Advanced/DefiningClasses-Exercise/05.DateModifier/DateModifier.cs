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
            int[] firstDateArgs = firstDate.Split().Select(int.Parse).ToArray();
            int[] secondDateArgs = secondDate.Split().Select(int.Parse).ToArray();

            DateTime first = new DateTime(firstDateArgs[0], firstDateArgs[1], firstDateArgs[2]);
            DateTime second = new DateTime(secondDateArgs[0], secondDateArgs[1], secondDateArgs[2]);

            return Math.Abs((first - second).Days);
        }
    }
}
