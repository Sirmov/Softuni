using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	N1 – цяло число в интервала[0...40 000]
            //•	N2 – цяло число в интервала[0...40 000]
            //•	Оператор – един символ измежду: „+“, „-“, „*“, „/“, „%“
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();

            double result = 0;
            switch (symbol)
            {
                case "+":
                    result = num1 + num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} + {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} + {num2} = {result} - odd");
                    }
                    break;
                case "-":
                    result = num1 - num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} - {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} - {num2} = {result} - odd");
                    }
                    break;
                case "*":
                    result = num1 * num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} * {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} * {num2} = {result} - odd");
                    }
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine($"{num1} / {num2} = {result:F2}");
                    }
                    break;
                case "%":
                    if (num2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    else
                    {
                        result = num1 % num2;
                        Console.WriteLine($"{num1} % {num2} = {result}");
                    }
                    break;
            }
        }
    }
}
