using System;

namespace _07.FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());
            double A = 0;
            double B = 0;
            double V = 0;
            double G = 0;
            for (int i = 0; i < fans; i++)
            {
                string currentFan = Console.ReadLine();
                switch (currentFan)
                {
                    case "A":
                        A++;
                        break;
                    case "B":
                        B++;
                        break;
                    case "V":
                        V++;
                        break;
                    case "G":
                        G++;
                        break;
                }
            }
            Console.WriteLine($"{A / fans * 100:F2}%");
            Console.WriteLine($"{B / fans * 100:F2}%");
            Console.WriteLine($"{V / fans * 100:F2}%");
            Console.WriteLine($"{G / fans * 100:F2}%");
            Console.WriteLine($"{1.00 * fans / capacity * 100:F2}%");
        }
    }
}
