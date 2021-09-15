using System;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int freeVolume = width * lenght * height;
            int takenVolume = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Done")
                {
                    Console.WriteLine($"{freeVolume - takenVolume} Cubic meters left.");
                    break;
                }
                takenVolume += int.Parse(input);
                if (takenVolume > freeVolume)
                {
                    Console.WriteLine($"No more free space! You need {takenVolume - freeVolume} Cubic meters more.");
                    break;
                }
            }

        }
    }
}
