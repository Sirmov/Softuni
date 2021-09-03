using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegs = int.Parse(Console.ReadLine());
            double maxVolume = double.MinValue;
            string maxVolumeModel = string.Empty;

            for (int i = 0; i < kegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    maxVolumeModel = model;
                }
            }

            Console.WriteLine(maxVolumeModel);
        }
    }
}
