using System;

namespace _01.UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            for (int i = 1; i <= firstNum; i++)
            {
                for (int j = 1; j <= secondNum; j++)
                {
                    for (int k = 1; k <= thirdNum; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0 && isPrime(j))
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }

        static bool isPrime(int num)
        {
            int a = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    a++;
                }
            }
            if (a == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
