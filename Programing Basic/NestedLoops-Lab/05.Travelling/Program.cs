using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destionation = "";
            double budget = 0;
            double savedMoney = 0;

            while (destionation != "End")
            {
                destionation = Console.ReadLine();
                if (destionation == "End")
                {
                    break;
                }
                budget = double.Parse(Console.ReadLine());
                while (savedMoney < budget)
                {
                    savedMoney += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destionation}!");
                savedMoney = 0;
            }
        }
    }
}
