using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double currGradeSum = 0;
            double gradeSum = 0;
            int tests = 0;
            while (input != "Finish")
            {
                for (int i = 0; i < judges; i++)
                {
                    double currGrade = double.Parse(Console.ReadLine());
                    currGradeSum += currGrade;
                    gradeSum += currGrade;
                }
                Console.WriteLine($"{input} - {currGradeSum/judges:F2}.");
                currGradeSum = 0;
                tests++;
                input = Console.ReadLine();
            }
            tests *= judges;
            Console.WriteLine($"Student's final assessment is {gradeSum/tests:F2}.");
        }
    }
}
