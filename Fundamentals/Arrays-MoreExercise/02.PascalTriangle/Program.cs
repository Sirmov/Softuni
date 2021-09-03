using System;
using System.Linq;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[] curr = new long[rows];
            long[] temp = new long[rows];
            string[] output = new string[rows];

            curr[0] = 1;
            temp[0] = 1;
            output[0] = "1";

            Console.WriteLine(1);

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    long up = temp[j];
                    long left = temp[j - 1];
                    curr[j] = up + left;
                }

                temp = curr.ToArray();

                for (int j = 1; j <= i; j++)
                {
                    output[j] = curr[j].ToString();
                }

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(output[j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
