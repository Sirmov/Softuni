using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
