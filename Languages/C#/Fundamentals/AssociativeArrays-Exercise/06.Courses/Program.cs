using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string name = input.Split(" : ")[0];
                string student = input.Split(" : ")[1];

                if (!courses.ContainsKey(name))
                {
                    courses.Add(name, new List<string>());
                }

                courses[name].Add(student);
                input = Console.ReadLine();
            }

            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, y => y.Value);

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
