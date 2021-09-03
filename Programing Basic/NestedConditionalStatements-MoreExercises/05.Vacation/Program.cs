using System;

namespace _05.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string location = "";
            string placeToStay = "";
            double price = 0;

            //•	При бюджет по - малък или равен от 1000лв.:
            //o Настаняване в "Camp"
            //o Според сезона локацията ще е една от следните и ще струва определен процент от бюджета:
            //	Лято – Аляска – 65 % от бюджета
            //	Зима – Мароко – 45 % от бюджета
            
            //•	При бюджет по - голям от 1000лв.и по-малък или равен от 3000лв.:
            //o Настаняване в "Hut"
            //o Според сезона локацията ще е една от следните и ще струва определен процент от бюджета:
            //	Лято – Аляска – 80 % от бюджета
            //	Зима – Мароко – 60 % от бюджета
            
            //•	При бюджет по - голям от 3000лв.:
            //o Настаняване в "Hotel"
            //o Според сезона локацията ще е една от следните и ще струва 90 % от бюджета:
            //	Лято – Аляска
            //	Зима – Мароко


            if (budget <= 1000)
            {
                placeToStay = "Camp";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        price = budget * 0.65;
                        break;
                    case "Winter":
                        location = "Morocco";
                        price = budget * 0.45;
                        break;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                placeToStay = "Hut";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        price = budget * 0.80;
                        break;
                    case "Winter":
                        location = "Morocco";
                        price = budget * 0.60;
                        break;
                }
            }
            else if (budget > 3000)
            {
                placeToStay = "Hotel";
                price = budget * 0.90;
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        break;
                    case "Winter":
                        location = "Morocco";
                        break;
                }
            }
            Console.WriteLine($"{location} – {placeToStay} – {price:F2}");
        }
    }
}
