using System;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] steps = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double leftTime = 0;
            double rightTime = 0;

            for (int i = 0; i < steps.Length / 2; i++)
            {
                if (steps[i] == 0)
                {
                    leftTime -= leftTime * 0.2;
                }
                else
                {
                    leftTime += steps[i];
                }
            }

            for (int i = steps.Length - 1; i > steps.Length / 2; i--)
            {
                if (steps[i] == 0)
                {
                    rightTime -= rightTime * 0.2;
                }
                else
                {
                    rightTime += steps[i];
                }
            }

            if (leftTime < rightTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftTime}");
            }
            else if (rightTime < leftTime)
            {
                Console.WriteLine($"The winner is right with total time: {rightTime}");
            }
        }
    }
}
