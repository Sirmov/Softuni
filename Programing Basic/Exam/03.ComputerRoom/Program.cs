using System;

namespace _03.ComputerRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            //• На първия ред - месецът - текст с възможности: "march", "april", "may", "june", "july", "august"
            //• На втория ред - броят на прекараните часове - цяло число в диапазона[1...10]
            //• На третия ред - броят на хората в групата -цяло число в диапазона[1...10]
            //• На четвъртия ред - времето от деня – текст с възможности: "day" или "night"
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            //   Март до Май Юни до Август
            //Ден 10.50 лв / ч 12.60 лв / ч
            //Нощ 8.40 лв / ч 10.20 лв / ч
            double price = 0;
            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    if (time == "day")
                    {
                        price = 10.50;
                    }
                    else
                    {
                        price = 8.40;
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    if (time == "day")
                    {
                        price = 12.60;
                    }
                    else
                    {
                        price = 10.20;
                    }
                    break;
            }
            if (people >= 4)
            {
                price -= price * 0.10;
            }
            if (hours >= 5)
            {
                price -= price * 0.50;
            }
            Console.WriteLine($"Price per person for one hour: {price:F2}");
            Console.WriteLine($"Total cost of the visit: {price * people * hours:F2}");
        }
    }
}
