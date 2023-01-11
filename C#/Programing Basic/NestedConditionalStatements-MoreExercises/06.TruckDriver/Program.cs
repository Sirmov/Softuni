using System;

namespace _06.TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometersForMonth = double.Parse(Console.ReadLine());
            double salary = 0;

            //                          Пролет / Есен   Лято            Зима
            //км на месец <= 5000          0.75 лв./ км 0.90 лв./ км 1.05 лв./ км
            //5000 < км на месец <= 10000  0.95 лв./ км 1.10 лв./ км 1.25 лв./ км
            //10000 < км на месец <= 20000 1.45 лв./ км – за който и да е сезон

            switch (season)
            {
                case "Spring":
                case "Autumn":
                    if (kilometersForMonth <= 5000)
                    {
                        salary = 0.75;
                    }
                    else if (kilometersForMonth > 5000 && kilometersForMonth <= 10000)
                    {
                        salary = 0.95;
                    }
                    else if (kilometersForMonth > 10000 && kilometersForMonth <= 20000)
                    {
                        salary = 1.45;
                    }
                    break;
                case "Summer":
                    if (kilometersForMonth <= 5000)
                    {
                        salary = 0.90;
                    }
                    else if (kilometersForMonth > 5000 && kilometersForMonth <= 10000)
                    {
                        salary = 1.10;
                    }
                    else if (kilometersForMonth > 10000 && kilometersForMonth <= 20000)
                    {
                        salary = 1.45;
                    }
                    break;
                case "Winter":
                    if (kilometersForMonth <= 5000)
                    {
                        salary = 1.05;
                    }
                    else if (kilometersForMonth > 5000 && kilometersForMonth <= 10000)
                    {
                        salary = 1.25;
                    }
                    else if (kilometersForMonth > 10000 && kilometersForMonth <= 20000)
                    {
                        salary = 1.45;
                    }
                    break;
            }
            salary *= kilometersForMonth;
            salary *= 4;
            salary -= salary * 0.10;
            Console.WriteLine($"{salary:F2}");
        }
    }
}
