using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses;
            if (capacity >= people)
            {
                courses = 1;
            }
            else if (people % capacity == 0)
            {
                courses = people / capacity;
            }
            else
            {
                courses = people / capacity + 1;
            }

            Console.WriteLine(courses);
        }
    }
}
