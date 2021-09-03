using System;

namespace _05.DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallLenght = double.Parse(Console.ReadLine()) * 100;
            double hallWidth = double.Parse(Console.ReadLine()) * 100;
            double wardrobeSide = double.Parse(Console.ReadLine()) * 100;
            double hallArea = hallLenght * hallWidth;
            double wardrobeArea = wardrobeSide * wardrobeSide;
            double benchArea = hallArea / 10;
            hallArea = hallArea - (wardrobeArea + benchArea);
            double dancers = Math.Floor(hallArea / 7040);
            Console.WriteLine(dancers);
        }
    }
}
