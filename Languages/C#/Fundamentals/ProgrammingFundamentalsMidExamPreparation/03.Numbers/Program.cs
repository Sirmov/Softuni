using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            if (numbers.Count(x => x > numbers.Average()) == 0)
            {
                Console.WriteLine("No");
            }
            else
            { 
                Console.WriteLine(string.Join(" ", numbers.Where(x => x > numbers.Average()).OrderByDescending(x => x).Take(5)));
            }
        }
    }
}
