using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MilitaryElite
{
    class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, params Mission[] missions)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions.ToList();
        }

        public List<Mission> Missions { get; set; }

        public void CompleteMission()
        {
            throw new NotImplementedException();
        }
    }
}
