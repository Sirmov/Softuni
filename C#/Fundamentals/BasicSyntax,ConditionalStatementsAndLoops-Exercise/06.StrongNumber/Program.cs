using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int digits = num.ToString().Length;
            int sum = 0;

            for (int i = 0; i < digits; i++)
            {
                int curr = int.Parse(num.ToString()[i].ToString());
                int factorial = 1;
                for (int j = 1; j <= curr; j++)
                {
                    factorial *= j;
                }
                sum += factorial;
            }
            if (sum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
