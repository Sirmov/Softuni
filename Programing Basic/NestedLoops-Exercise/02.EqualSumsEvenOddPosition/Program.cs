using System;

namespace _02.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;
            for (int i = start; i <= end; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    string currNum = i.ToString();
                    char currChar = currNum[j];
                    int digit = int.Parse(currChar.ToString());
                    if (j % 2 != 0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;
                    }
                }
                if (evenSum == oddSum)
                {
                    Console.Write($"{i} ");
                }
                evenSum = 0;
                oddSum = 0;
            }
        }
    }
}
