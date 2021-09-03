using System;

namespace _08.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine()) / 10;
            double width = double.Parse(Console.ReadLine()) / 10;
            double height = double.Parse(Console.ReadLine()) / 10;
            double procent = double.Parse(Console.ReadLine()) / 100;
            double volume = lenght * width * height;
            volume = volume * (1 - procent);
            Console.WriteLine(volume);
        }
    }
}
