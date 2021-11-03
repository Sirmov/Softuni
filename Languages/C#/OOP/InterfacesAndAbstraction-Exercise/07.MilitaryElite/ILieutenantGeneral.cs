using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    interface ILieutenantGeneral : IPrivate
    {
        public List<IPrivate> Squad { get; set; }
    }
}
