using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            int playerIndex = roster.FindIndex(p => p.Name == name);

            if (playerIndex == -1)
            {
                return false;
            }
            else
            {
                roster.RemoveAt(playerIndex);
                return true;
            }
        }

        public void PromotePlayer(string name)
        {
            int playerIndex = roster.FindIndex(p => p.Name == name);

            if (playerIndex != -1)
            {
                roster[playerIndex].Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            int playerIndex = roster.FindIndex(p => p.Name == name);

            if (playerIndex != -1)
            {
                roster[playerIndex].Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] players = roster.FindAll(p => p.Class == @class).ToArray();
            roster.RemoveAll(p => p.Class == @class);
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
