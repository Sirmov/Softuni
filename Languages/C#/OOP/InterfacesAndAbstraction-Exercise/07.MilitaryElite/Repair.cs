using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    class Repair
    {
        public Repair(string partName, int repairTime)
        {
            PartName = partName;
            RepairTime = repairTime;
        }

        public string PartName { get; set; }

        public int RepairTime { get; set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {RepairTime}";
        }
    }
}
