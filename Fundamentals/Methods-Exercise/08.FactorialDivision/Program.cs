using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            long num1 = long.Parse(Console.ReadLine());
            long num2 = long.Parse(Console.ReadLine());

            Console.WriteLine($"{FactorialDivision(num1, num2):F2}");
        }

        static decimal FactorialDivision(long num1, long num2)
        {
            decimal first = 1;
            decimal second = 1;

            for (int i = 1; i <= num1; i++)
            {
                first *= i;
            }

            for (int i = 1; i <= num2; i++)
            {
                second *= i;
            }

            decimal result = first / second;

            return result;
        }
    }
}
