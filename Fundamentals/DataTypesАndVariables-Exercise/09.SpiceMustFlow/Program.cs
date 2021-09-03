using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int yield = startingYield;

            int spice = 0;
            int days = 0;

            while (yield >= 100)
            {
                days++;
                spice += yield;
                yield -= 10;
                spice -= 26;
            }

            if (spice >= 26)
            {
                spice -= 26;
            }
            else
            {
                spice = 0;
            }

            Console.WriteLine(days);
            Console.WriteLine(spice);
        }
    }
}
