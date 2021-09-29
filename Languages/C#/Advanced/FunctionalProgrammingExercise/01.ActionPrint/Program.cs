using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            Action<string> Print = s => Console.WriteLine(s);

            foreach (var item in strings)
            {
                Print(item);
            }
        }
    }
}
