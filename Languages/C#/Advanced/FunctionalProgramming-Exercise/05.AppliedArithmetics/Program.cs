using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            

            string command = Console.ReadLine();
            while (command != "end")
            {
                Func<int, int> func = n => n;

                if (command == "add")
                {
                    func = n => n + 1;
                }
                else if (command == "multiply")
                {
                    func = n => n * 2;
                }
                else if (command == "subtract")
                {
                    func = n => n - 1;
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }

                numbers = numbers.Select(func).ToArray();
                command = Console.ReadLine();
            }
        }
    }
}
