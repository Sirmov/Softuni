using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Predicate<string> isShorter = s => s.Length <= n;

            foreach (var name in names)
            {
                if (isShorter(name))
                {
                    Console.WriteLine(name + " ");
                }
            }
        }
    }
}
