using System;

namespace _07.SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string group = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            double price = 0;
            string sport = "";
            //            Зимна ваканция  Пролетна ваканция   Лятна ваканция
            //момичета      Gymnastics       Athletics          Volleyball
            //момчета        Judo             Tennis            Football
            //смесенагрупа   Ski              Cycling           Swimming

            switch (season)
            {
                case "Winter":
                    if (group == "boys" || group == "girls")
                    {
                        price = 9.60;
                    }
                    else
                    {
                        price = 10.00;
                    }
                    if (group == "girls")
                    {
                        sport = "Gymnastics";
                    }
                    else if (group == "boys")
                    {
                        sport = "Judo";
                    }
                    else if (group == "mixed")
                    {
                        sport = "Ski";
                    }
                    break;
                case "Spring":
                    if (group == "boys" || group == "girls")
                    {
                        price = 7.20;
                    }
                    else
                    {
                        price = 9.50;
                    }
                    if (group == "girls")
                    {
                        sport = "Athletics";
                    }
                    else if (group == "boys")
                    {
                        sport = "Tennis";
                    }
                    else if (group == "mixed")
                    {
                        sport = "Cycling";
                    }
                    break;
                case "Summer":
                    if (group == "boys" || group == "girls")
                    {
                        price = 15.00;
                    }
                    else
                    {
                        price = 20.00;
                    }
                    if (group == "girls")
                    {
                        sport = "Volleyball";
                    }
                    else if (group == "boys")
                    {
                        sport = "Football";
                    }
                    else if (group == "mixed")
                    {
                        sport = "Swimming";
                    }
                    break;
            }
            price *= nights * students;
            if (students >= 10 && students < 20)
            {
                price -= price * 0.05;
            }
            else if (students >= 20 && students < 50)
            {
                price -= price * 0.15;
            }
            else if (students >= 50)
            {
                price -= price * 0.50;
            }
            Console.WriteLine($"{sport} {price:F2} lv.");
        }
    }
}
