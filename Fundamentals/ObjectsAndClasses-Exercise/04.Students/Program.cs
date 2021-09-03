using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>(n);

            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine().Split();
                string firstName = student[0];
                string lastName = student[1];
                double grade = double.Parse(student[2]);
                students.Add(new Student(firstName, lastName, grade));
            }

            students = students.OrderByDescending(x => x.Grade).ToList();
            
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].ToString());
            }
        }
    }

    class Student
    {
        private string firstName;
        private string lastName;
        private double grade;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public Student(string firstName, string lastName, double grade)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}: {grade:F2}";
        }
    }
}
