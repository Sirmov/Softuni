using System;

namespace _01.Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int soap = int.Parse(Console.ReadLine()) * 750;
            string input = Console.ReadLine();
            int days = 1;
            int pots = 0;
            int dishes = 0;
            while (input != "End")
            {
                if (days % 3 == 0)
                {
                    soap -= int.Parse(input) * 15;
                    pots += int.Parse(input);
                }
                else
                {
                    soap -= int.Parse(input) * 5;
                    dishes += int.Parse(input);
                }
                if (soap < 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(soap)} ml. more necessary!");
                    return;
                }
                days++;
                input = Console.ReadLine();
            }
            Console.WriteLine("Detergent was enough!");
            Console.WriteLine($"{dishes} dishes and {pots} pots were washed.");
            Console.WriteLine($"Leftover detergent {soap} ml.");
        }
    }
}
