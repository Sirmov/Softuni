using System;

namespace _04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                char curr = char.Parse(Console.ReadLine());
                sum += (int)curr;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
