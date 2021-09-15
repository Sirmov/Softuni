using System;

namespace _08.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());
            double excellentScholarship = 0;
            double socialScholarship = 0;

            if (income < minimalSalary && grade > 4.5)
            {
                socialScholarship = minimalSalary * 0.35;
            }
            if (grade >= 5.50)
            {
                excellentScholarship = grade * 25;
            }

            if (excellentScholarship != 0 && socialScholarship != 0)
            {
                if (socialScholarship > excellentScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
                else if (excellentScholarship > socialScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScholarship)} BGN");
                }
                else if (excellentScholarship == socialScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScholarship)} BGN");
                }
            }
            else if (excellentScholarship == 0 && socialScholarship == 0)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (excellentScholarship != 0 && socialScholarship == 0)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScholarship)} BGN");
            }
            else if (excellentScholarship == 0 && socialScholarship != 0)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
        }
    }
}
