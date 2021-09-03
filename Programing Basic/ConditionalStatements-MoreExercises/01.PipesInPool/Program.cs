using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int V = int.Parse(Console.ReadLine());
            int P1 = int.Parse(Console.ReadLine());
            int P2 = int.Parse(Console.ReadLine());
            double H = double.Parse(Console.ReadLine());
            double P1V = P1 * H;
            double P2V = P2 * H;
            double PV = P1V + P2V;
            double Vprocent = Math.Round((PV / V) * 100, 2);
            double P1procent = Math.Round((P1V / PV) * 100, 2);
            double P2procent = Math.Round((P2V / PV) * 100, 2);
            if (PV <= V)
            {
                Console.WriteLine($"The pool is {Vprocent.ToString("F2")}% full. Pipe 1: {P1procent}%. Pipe 2: {P2procent}%.");
            }
            else
            {
                Console.WriteLine($"For {H} hours the pool overflows with {PV - V} liters.");
            }
        }
    }
}