using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int efficincy = a + b + c;
            int people = int.Parse(Console.ReadLine());
            int hours = 0;
            while (people > 0)
            {
                people -= efficincy;
                hours++;
                if (hours % 4 == 0)
                {
                    hours++;
                }
            }
            Console.WriteLine($"Time needed: {hours:F0}h.");
        }
    }
}
