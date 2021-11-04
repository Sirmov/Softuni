using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    class Mission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }

        public string State
        {
            get => state;

            set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    state = value;
                }
                else
                {
                    throw new ArgumentException("Invalid mission state.");
                }
            }
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
