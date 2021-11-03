using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    interface ISoldier
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
