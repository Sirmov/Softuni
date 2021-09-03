using System;

namespace _04.VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double totalHours = pages / pagesPerHour;
            double hoursPerDay = totalHours / days;
            Console.WriteLine(hoursPerDay);
        }
    }
}
