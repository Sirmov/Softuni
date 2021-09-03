using System;

namespace _08.TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= rows; j++)
                {
                    Console.Write($"{i} ");
                }
                    Console.WriteLine();
                    rows++;
            }
        }
    }
}
