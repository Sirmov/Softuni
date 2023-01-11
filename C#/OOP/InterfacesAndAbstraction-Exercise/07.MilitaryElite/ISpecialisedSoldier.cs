using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    interface ISpecialisedSoldier : IPrivate
    {
        public string Corps { get; set; }
    }
}
