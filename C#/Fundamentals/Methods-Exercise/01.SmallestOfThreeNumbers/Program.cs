using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int result = Min(firstNum, secondNum, thirdNum);

            Console.WriteLine(result);
        }

        static int Min(int n1, int n2, int n3)
        {
            int min = Math.Min(n1, Math.Min(n2, n3));

            return min;
        }
    }
}
