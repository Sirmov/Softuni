using System;

namespace _04.TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            double taxi = 0;
            double bus = 0;
            double train = 0;

            if (timeOfDay == "day")
            {
                taxi = 0.70 + kilometers * 0.79;
                if (kilometers >= 20)
                {
                    bus = kilometers * 0.09;
                }
                if (kilometers >=100)
                {
                    train = kilometers * 0.06;
                }
            }
            else
            {
                taxi = 0.70 + kilometers * 0.90;
                if (kilometers >= 20)
                {
                    bus = kilometers * 0.09;
                }
                if (kilometers >= 100)
                {
                    train = kilometers * 0.06;
                }
            }

            if (kilometers < 20)
            {
                Console.WriteLine($"{taxi:F2}");
            }
            else if (kilometers < 100)
            {
                Console.WriteLine($"{Math.Min(taxi, bus):F2}");
            }
            else
            {
                Console.WriteLine($"{Math.Min(Math.Min(taxi, bus), Math.Min(bus, train)):F2}");
            }
        }
    }
}
