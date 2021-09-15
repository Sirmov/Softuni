using System;

namespace _08.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int otherPets = int.Parse(Console.ReadLine());
            double sum = dogs * 2.50 + otherPets * 4;
            Console.WriteLine($"{sum} lv.");
        }
    }
}
