using System;

namespace _08.GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int year = 1;
            double gradesSum = 0;
            double averageGrade = 0;
            int failedYears = 0;
            while (true)
            {
                if (failedYears > 1)
                {
                    Console.WriteLine($"{name} has been excluded at {year-2} grade");
                    break;
                }
                if (year > 12)
                {
                    averageGrade = gradesSum / 12;
                    Console.WriteLine($"{name} graduated. Average grade: {averageGrade:F2}");
                    break;
                }
                double currentGrade = double.Parse(Console.ReadLine());
                if (currentGrade < 4)
                {
                    failedYears++;
                }
                gradesSum += currentGrade;
                year++;
            }
        }
    }
}
