using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    interface ICommando : ISpecialisedSoldier
    {
        public List<Mission> Missions { get; set; }

        public void CompleteMission();
    }
}
