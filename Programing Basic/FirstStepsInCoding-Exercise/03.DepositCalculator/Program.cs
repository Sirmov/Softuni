using System;

namespace _03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int range = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine()) / 100;
            double sum = deposit + range * ((deposit * interest) / 12);
            Console.WriteLine(sum);
        }
    }
}
