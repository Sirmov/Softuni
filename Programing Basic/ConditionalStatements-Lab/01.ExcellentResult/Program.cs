using System;

namespace _01.ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            double score = double.Parse(Console.ReadLine());
            if (score >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
