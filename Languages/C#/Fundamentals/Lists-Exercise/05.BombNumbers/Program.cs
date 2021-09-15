using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombProperties = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bomb = bombProperties[0];
            int bombPower = bombProperties[1];

            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    if (numbers[i] == bomb)
            //    {
            //        int lowerRange = i - bombPower;
            //        int count = 1 + 2 * bombPower;

            //        if (lowerRange < 0)
            //        {
            //            lowerRange = 0;
            //        }

            //        if (lowerRange + count > numbers.Count)
            //        {
            //            count = numbers.Count - lowerRange;
            //        }

            //        numbers.RemoveRange(lowerRange, count);
            //        i = 0;
            //    }
            //}

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    if (i + bombPower >= numbers.Count)
                    {
                        numbers.RemoveRange(i, numbers.Count - i);
                    }
                    else
                    {
                        numbers.RemoveRange(i, bombPower + 1);
                    }

                    if (i - bombPower < 0)
                    {
                        numbers.RemoveRange(0, i);
                    }
                    else
                    {
                        numbers.RemoveRange(i - bombPower, bombPower);
                    }
                    
                    i = 0;
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
