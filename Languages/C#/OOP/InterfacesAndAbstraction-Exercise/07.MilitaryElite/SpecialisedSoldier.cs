using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps
        {
            get => corps;

            set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
                else
                {
                    throw new ArgumentException("Invalid corps.");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");

            return sb.ToString().TrimEnd();
        }
    }
}
