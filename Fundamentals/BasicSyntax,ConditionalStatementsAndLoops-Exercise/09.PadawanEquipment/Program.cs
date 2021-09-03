using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lightsabers = Math.Ceiling(students * 0.1) + students;
            int belts = students - students / 6;
            int robes = students;

            double price = lightsabers * lightsaberPrice + robes * robePrice + belts * beltPrice;

            if (money >= price)
            {
                Console.WriteLine($"The money is enough - it would cost {price:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {price - money:F2}lv more.");
            }
        }
    }
}
