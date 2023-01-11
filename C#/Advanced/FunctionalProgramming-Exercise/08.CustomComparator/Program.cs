using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Comparison<int> compare = (x, y) => IntCompare(x, y);
            Array.Sort(numbers, compare);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int IntCompare(int x, int y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    int retval = 0;

                    if (x % 2 == 0 && y % 2 != 0)
                    {
                        retval = -1;
                    }
                    else if (x % 2 == 0 && y % 2 == 0)
                    {
                        retval = 0;
                    }
                    else if (x % 2 != 0 && y % 2 == 0)
                    {
                        retval = 1;
                    }

                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return x.CompareTo(y);
                    }
                }
            }
        }
    }
}
