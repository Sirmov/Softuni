using System;
using System.Linq;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] input2 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < input2.Length; i++)
            {
                for (int j = 0; j < input1.Length; j++)
                {
                    if (input2[i] == input1[j])
                    {
                        Console.Write(input2[i] + " ");
                    }
                }
            }
        }
    }
}
