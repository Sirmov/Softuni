using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            for (int i = 8; i <= end; i++)
            {
                int digits = SumDigits(i);
                bool isOdd = isOddDigit(i);
                if (digits % 8 == 0 && isOdd)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool isOddDigit(int i)
        {
            bool isOdd = false;

            while (i != 0)
            {
                if ((i % 10) % 2 != 0)
                {
                    isOdd = true;
                }

                i /= 10;
            }

            return isOdd;
        }

        static int SumDigits(int i)
        {
            int sum = 0;

            while (i != 0)
            {
                sum += i % 10;
                i /= 10;
            }

            return sum;
        }
    }
}
