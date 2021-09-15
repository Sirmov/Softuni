using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int slices = width * height;
            string input = Console.ReadLine();
            while (input != "STOP")
            {
                int currentSlices = int.Parse(input);
                slices -= currentSlices;
                if (slices < 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(slices)} pieces more.");
                    Environment.Exit(0);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{slices} pieces are left.");
        }
    }
}
