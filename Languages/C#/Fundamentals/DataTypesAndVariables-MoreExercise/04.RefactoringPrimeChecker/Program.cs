using System;

namespace _04.RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 2; i <= num; i++)
            {
                bool isPrime = false;
                int count = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        count++;
                    }
                }

                if (count < 2)
                {
                    isPrime = true;
                }
                Console.WriteLine("{0} -> {1}", i, isPrime.ToString().ToLower());
            }

        }
    }
}
