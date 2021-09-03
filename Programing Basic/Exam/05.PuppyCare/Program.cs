using System;

namespace _05.PuppyCare
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine()) * 1000;
            string input = Console.ReadLine();
            while (input != "Adopted")
            {
                food -= int.Parse(input);
                input = Console.ReadLine();
            }
            if (food < 0)
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(food)} grams more.");
            }
            else
            {
                Console.WriteLine($"Food is enough! Leftovers: {food} grams.");
            }
        }
    }
}
