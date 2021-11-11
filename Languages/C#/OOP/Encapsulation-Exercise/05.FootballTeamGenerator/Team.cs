using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    internal class Team
    {
        private List<Player> players;
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int) Math.Floor(this.players.Average(p => p.SkillLevel));
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            
            if (players.RemoveAll(p => p.Name == name) == 0)
            {
                throw new InvalidOperationException($"Player {name} is not in {this.name} team.");
            }
        }
    }
}
