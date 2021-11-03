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
    }
}
