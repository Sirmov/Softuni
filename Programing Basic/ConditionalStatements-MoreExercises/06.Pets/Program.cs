using System;

namespace _06.Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            double dog = double.Parse(Console.ReadLine());
            double cat = double.Parse(Console.ReadLine());
            double turtle = double.Parse(Console.ReadLine()) / 1000;

            double foodSum = dog * days + cat * days + turtle * days;

            if (food >= foodSum)
            {
                Console.WriteLine($"{Math.Floor(food - foodSum)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(foodSum - food)} more kilos of food are needed.");
            }
        }
    }
}
