using System;

namespace _04.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double students = int.Parse(Console.ReadLine());
            double success = 0.00;
            double fail = 0;
            double average = 0;
            double good = 0;
            double perfect = 0;
            double studentSuccess;
            for (int i = 0; i < students; i++)
            {
                studentSuccess = double.Parse(Console.ReadLine());
                success += studentSuccess;
                if (studentSuccess < 3)
                {
                    fail++;
                }
                else if (studentSuccess >= 3 && studentSuccess < 4)
                {
                    average++;
                }
                else if (studentSuccess >= 4 && studentSuccess < 5)
                {
                    good++;
                }
                else if (studentSuccess >= 5)
                {
                    perfect++;
                }
            }
            Console.WriteLine($"Top students: {(perfect/students) * 100:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(good/students) * 100:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(average/students) * 100:F2}%");
            Console.WriteLine($"Fail: {(fail/students) * 100:F2}%");
            Console.WriteLine($"Average: {success/students:F2}");
        }
    }
}
