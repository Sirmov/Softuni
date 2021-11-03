using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MilitaryElite
{
    class LeutenantGeneral : Private, ILieutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, decimal salary, params IPrivate[] squad)
            : base(id, firstName, lastName, salary)
        {
            Squad = squad.ToList();
        }

        public List<IPrivate> Squad { get; set; }
    }
}
