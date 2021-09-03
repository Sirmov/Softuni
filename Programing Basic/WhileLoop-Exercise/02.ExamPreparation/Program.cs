using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());
            int worse = 0;
            int problems = 0;
            double gradesSum = 0;
            string problemName = "";
            string currentGrade = "";
            string lastProblem = "";

            while (worse < limit)
            {
                problemName = Console.ReadLine();
                if (problemName == "Enough")
                {
                    Console.WriteLine($"Average score: {gradesSum / problems:F2}");
                    Console.WriteLine($"Number of problems: {problems}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    break;
                }
                currentGrade = Console.ReadLine();
                if (double.Parse(currentGrade) <= 4)
                {
                    worse++;
                }
                gradesSum += double.Parse(currentGrade);
                lastProblem = problemName;
                problems++;
            }
            if (worse >= limit)
            {
                Console.WriteLine($"You need a break, {worse} poor grades.");
            }
        }
    }
}
