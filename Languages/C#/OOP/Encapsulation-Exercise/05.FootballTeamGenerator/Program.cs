using System;
using System.Collections.Generic;

namespace _05.FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command.Split(';');
                string operation = commandArgs[0];
                string teamName = commandArgs[1];

                try
                {
                    if (operation == "Team")
                    {
                        teams.Add(teamName, new Team(teamName));
                    }
                    else if (operation == "Add")
                    {
                        string playerName = commandArgs[2];
                        int endurance = int.Parse(commandArgs[3]);
                        int sprint = int.Parse(commandArgs[4]);
                        int dribble = int.Parse(commandArgs[5]);
                        int passing = int.Parse(commandArgs[6]);
                        int shooting = int.Parse(commandArgs[7]);

                        Player player = new Player(playerName, new Dictionary<string, int>
                    {
                        { "Endurance", endurance },
                        { "Sprint", sprint },
                        { "Dribble", dribble },
                        { "Passing", passing },
                        { "Shooting", shooting }
                    });

                        if (!teams.ContainsKey(teamName))
                        {
                            ThrowInvalidTeamException(teamName);
                        }

                        teams[teamName].AddPlayer(player);
                    }
                    else if (operation == "Remove")
                    {
                        string playerName = commandArgs[2];

                        if (!teams.ContainsKey(teamName))
                        {
                            ThrowInvalidTeamException(teamName);
                        }

                        teams[teamName].RemovePlayer(playerName);
                    }
                    else if (operation == "Rating")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            ThrowInvalidTeamException(teamName);
                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }

        public static void ThrowInvalidTeamException(string teamName)
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
    }
}
