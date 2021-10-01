using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int threshold = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> isBigger = (name, threshold) => 
            name.Sum(x => x) >= threshold;


            Action<string[], int, Func<string, int, bool>> firstValid = (names, threshold, filter) => 
            {
                foreach (var name in names)
                {
                    if (filter(name, threshold))
                    {
                        Console.WriteLine(name);
                        break;
                    }
                }
            };

            firstValid(names, threshold, isBigger);
        }
    }
}
