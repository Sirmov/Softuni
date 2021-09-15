using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 0;
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input == "NoMoreMoney")
                {
                    Console.WriteLine($"Total: {balance:F2}");
                    break;
                }
                if (double.Parse(input) < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {balance:F2}");
                    break;
                }
                balance += double.Parse(input);
                Console.WriteLine($"Increase: {double.Parse(input):F2}");
            }
        }
    }
}
