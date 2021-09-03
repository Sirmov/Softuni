using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int numOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;
            //-"Roses", "Dahlias", "Tulips", "Narcissus", "Gladiolus"
            //Роза Далия   Лале Нарцис  Гладиола
            //5   3.80    2.80    3   2.50

            //•	Ако Нели купи повече от 80 Рози - 10 % отстъпка от крайната цена
            //•	Ако Нели купи повече от 90  Далии - 15 % отстъпка от крайната цена
            //•	Ако Нели купи повече от 80 Лалета - 15 % отстъпка от крайната цена
            //•	Ако Нели купи по-малко от 120 Нарциса - цената се оскъпява с 15 %
            //•	Ако Нели Купи по-малко от 80 Гладиоли - цената се оскъпява с 20 %

            switch (flowerType)
            {
                case "Roses":
                    price += numOfFlowers * 5.00;
                    if (numOfFlowers > 80)
                    {
                        price -= price * 0.10;
                    }
                    break;
                case "Dahlias":
                    price += numOfFlowers * 3.80;
                    if (numOfFlowers > 90)
                    {
                        price -= price * 0.15;
                    }
                    break;
                case "Tulips":
                    price += numOfFlowers * 2.80;
                    if (numOfFlowers > 80)
                    {
                        price -= price * 0.15;
                    }
                    break;
                case "Narcissus":
                    price += numOfFlowers * 3.00;
                    if (numOfFlowers < 120)
                    {
                        price += price * 0.15;
                    }
                    break;
                case "Gladiolus":
                    price += numOfFlowers * 2.50;
                    if (numOfFlowers < 80)
                    {
                        price += price * 0.20;
                    }
                    break;
            }
            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {numOfFlowers} {flowerType} and {budget - price:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price - budget:F2} leva more.");
            }
        }
    }
}
