using System;

namespace _04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int conbination = 0;
            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    conbination++;
                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{conbination} ({i} + {j} = {magicNum})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{conbination} combinations - neither equals {magicNum}");
        }
    }
}
