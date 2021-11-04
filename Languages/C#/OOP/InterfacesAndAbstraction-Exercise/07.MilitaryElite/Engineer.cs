using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MilitaryElite
{
    class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, params Repair[] repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs.ToList();
        }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine(" " + repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
