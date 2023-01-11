using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MilitaryElite
{
    class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, Mission[] missions)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions.ToList();
        }

        public List<Mission> Missions { get; set; }

        public void CompleteMission(string codeName)
        {
            int index = Missions.FindIndex(m => m.CodeName == codeName);

            if (index != -1)
            {
                Missions[index].State = "Finished";
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine(" " + mission.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
