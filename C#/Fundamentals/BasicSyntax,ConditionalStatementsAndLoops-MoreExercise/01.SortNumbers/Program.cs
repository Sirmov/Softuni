using System;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int min = int.MaxValue;
            int max = int.MinValue;

            if (firstNum < min)
            {
                min = firstNum;
            }
            if (secondNum < min)
            {
                min = secondNum;
            }
            if (thirdNum < min)
            {
                min = thirdNum;
            }

            if (firstNum > max)
            {
                max = firstNum;
            }
            if (secondNum > max)
            {
                max = secondNum;
            }
            if (thirdNum > max)
            {
                max = thirdNum;
            }

            int mid = 0;

            if (firstNum != max && firstNum != min)
            {
                mid = firstNum;
            }
            else if (secondNum != max && secondNum != min)
            {
                mid = secondNum;
            }
            else
            {
                mid = thirdNum;
            }

            Console.WriteLine(max);
            Console.WriteLine(mid);
            Console.WriteLine(min);
        }
    }
}
