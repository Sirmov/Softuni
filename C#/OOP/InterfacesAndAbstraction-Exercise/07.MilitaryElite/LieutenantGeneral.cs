using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MilitaryElite
{
    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, params IPrivate[] squad)
            : base(id, firstName, lastName, salary)
        {
            Squad = squad.ToList();
        }

        public List<IPrivate> Squad { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var soldier in Squad)
            {
                sb.AppendLine(" " + soldier.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
