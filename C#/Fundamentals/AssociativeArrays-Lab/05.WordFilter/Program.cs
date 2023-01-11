using System;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Console.WriteLine(string.Join("\r\n", words.Where(x => x.Length % 2 ==0)));
        }
    }
}
