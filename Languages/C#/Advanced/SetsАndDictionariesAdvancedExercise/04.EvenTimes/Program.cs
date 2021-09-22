using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            Dictionary<int, int> occurrences = new Dictionary<int, int>();

            for (int i = 0; i < numbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!occurrences.ContainsKey(number))
                {
                    occurrences[number] = 0;
                }

                occurrences[number]++;
            }

            foreach (var num in occurrences)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                    break;
                }
            }
        }
    }
}
