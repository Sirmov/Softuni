using System;

namespace _05._Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int projectHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            double workHours = days * 0.9 * 8 + workers * 2 * days;
            if (workHours >= projectHours)
            {
                Console.WriteLine($"Yes!{Math.Floor(workHours - projectHours)} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Ceiling(projectHours - workHours)} hours needed.");
            }

            
        }
    }
}
