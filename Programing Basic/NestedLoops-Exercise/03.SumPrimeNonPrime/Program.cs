using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int devideCounter = 0;
            int primeSum = 0;
            int nonprimeSum = 0;
            while (input != "stop")
            {
                int curr = int.Parse(input);
                if (curr < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    for (int i = 1; i <= curr; i++)
                    {
                        if (curr % i == 0)
                        {
                            devideCounter++;
                        }
                    }
                    if (devideCounter == 2)
                    {
                        primeSum += curr;
                    }
                    else
                    {
                        nonprimeSum += curr;
                    }
                }
                devideCounter = 0;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonprimeSum}");
        }
    }
}
