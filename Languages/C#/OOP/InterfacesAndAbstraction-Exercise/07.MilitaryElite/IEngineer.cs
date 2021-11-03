using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    interface IEngineer : ISpecialisedSoldier
    {
        public List<Repair> Repairs { get; set; }
    }
}
