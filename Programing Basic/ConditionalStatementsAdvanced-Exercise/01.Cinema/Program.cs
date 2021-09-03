using System;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Premiere – премиерна прожекция, на цена 12.00 лева.
            //•	Normal – стандартна прожекция, на цена 7.50 лева.
            //•	Discount – прожекция за деца, ученици и студенти на намалена цена от 5.00 лева.
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            double price = 0;
            double totalPrice = 0;

            switch (projectionType)
            {
                case "Premiere":
                    price = 12.00;
                    break;
                case "Normal":
                    price = 7.50;
                    break;
                case "Discount":
                    price = 5.00;
                    break;
            }
            totalPrice = price * rows * cols;
            Console.WriteLine($"{totalPrice:F2} leva");
        }
    }
}
