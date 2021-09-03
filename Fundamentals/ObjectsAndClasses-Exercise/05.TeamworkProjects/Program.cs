using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>(n);

            for (int i = 0; i < n; i++)
            {
                string[] team = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                if (SameTeam(teams, team[1]))
                {
                    Console.WriteLine($"Team {team[1]} was already created!");
                    continue;
                }

                if (SameCreator(teams, team[0]))
                {
                    Console.WriteLine($"{team[0]} cannot create another team!");
                    continue;
                }

                teams.Add(new Team(team[0], team[1]));
                Console.WriteLine($"Team {teams[teams.Count-1].Name} has been created by {teams[teams.Count - 1].Creator}!");
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] inputArgs = input.Split("->");
                string user = inputArgs[0];
                string team = inputArgs[1];
                AddMember(teams, user, team);
                input = Console.ReadLine();
            }

            List<Team> disbandTeams = CheckAndDisband(teams);
            teams = teams.OrderBy(x => x.Name).ToList();
            teams = teams.OrderByDescending(x => x.Members.Count).ToList();
            
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine(teams[i].ToString());
            }

            Console.WriteLine("Teams to disband:");

            for (int i = 0; i < disbandTeams.Count; i++)
            {
                Console.WriteLine(disbandTeams[i].Name);
            }
        }

        private static List<Team> CheckAndDisband(List<Team> teams)
        {
            List<Team> disbandTeams = new List<Team>(teams.Count);
            foreach (var team in teams)
            {
                if (team.Members.Count < 2)
                {
                    team.IsDisband = true;
                    disbandTeams.Add(team);
                }
            }
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].IsDisband)
                {
                    teams.RemoveAt(i);
                    i--;
                }
            }
            return disbandTeams.OrderBy(x => x.Name).ToList();
        }

        private static void AddMember(List<Team> teams, string user, string team)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Contains(user))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                    return;
                }
            }
            
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Name == team)
                {
                    teams[i].Members.Add(user);
                    return;
                }
            }

            Console.WriteLine($"Team {team} does not exist!");
            return;
        }

        private static bool SameCreator(List<Team> teams, string creator)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Creator == creator)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool SameTeam(List<Team> teams, string name)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Name == name)
                {
                    return true;
                }
            }

            return false;
        }
    }

    class Team
    {
        private string name;
        private string creator;
        private List<string> members = new List<string>();
        private bool isDisband = false;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }
        public List<string> Members
        {
            get { return members; }
            set { members = value; }
        }
        public bool IsDisband
        {
            get { return isDisband; }
            set { isDisband = value; }
        }

        public Team(string creator, string name)
        {
            this.creator = creator;
            this.name = name;
            this.members.Add(creator);
        }
        
        public override string ToString()
        {
            List<string> realMembers = members;
            realMembers.Remove(creator);
            realMembers.Sort();
            return $"{name}\n- {creator}\n-- " + string.Join("\n-- ", realMembers);
        }
    }
}
