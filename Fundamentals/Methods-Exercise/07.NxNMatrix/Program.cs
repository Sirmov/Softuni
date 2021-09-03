using System;
using System.Runtime.ExceptionServices;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintMatrix(n);
        }

        static void PrintMatrix(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                for (int k = 1; k <= i; k++)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
