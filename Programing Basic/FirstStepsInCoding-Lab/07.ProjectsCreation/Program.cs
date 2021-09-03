using System;

namespace _07.ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string architectName = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());
            Console.WriteLine($"The architect {architectName} will need {projects * 3} hours to complete {projects} project/s.");
        }
    }
}
