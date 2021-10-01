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


            Action<string[], int, Func<string, int, bool>> printFirstValid = (names, threshold, filter) =>
            Console.WriteLine(names.FirstOrDefault(n => filter(n, threshold)));

            //{
            //    foreach (var name in names)
            //    {
            //        if (filter(name, threshold))
            //        {
            //            Console.WriteLine(name);
            //            break;
            //        }
            //    }
            //};

            printFirstValid(names, threshold, isBigger);
        }
    }
}
