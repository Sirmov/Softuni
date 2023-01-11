using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int sum = Sum(first, second);
            int result = Subtract(sum, third);

            Console.WriteLine(result);
        }

        static int Subtract(int sum, int third)
        {
            int result = sum - third;

            return result;
        }

        private static int Sum(int first, int second)
        {
            int result = first + second;

            return result;
        }
    }
}
