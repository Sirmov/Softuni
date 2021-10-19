using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    class Player
    {
        public Player(string name, string @class)
        {
            Name = name;
            Class = @class;
            Rank = "Trial";
            Description = "n/a";
        }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.Append($"Description: {Description}");

            return sb.ToString().TrimEnd();
        }
    }
}
