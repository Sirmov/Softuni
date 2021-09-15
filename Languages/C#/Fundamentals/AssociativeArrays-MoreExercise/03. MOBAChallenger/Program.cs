using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> totalSkill = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "Season end")
            {
                string separator = input.Contains("vs") ? " vs " : " -> ";
                string[] inputArgs = input.Split(separator);

                if (separator == " -> ")
                {
                    string name = inputArgs[0];
                    string position = inputArgs[1];
                    int skill = int.Parse(inputArgs[2]);

                    if (!players.ContainsKey(name))
                    {
                        players.Add(name, new Dictionary<string, int>());
                    }

                    if (!players[name].ContainsKey(position))
                    {
                        players[name].Add(position, 0);
                    }

                    if (skill > players[name][position])
                    {
                        players[name][position] = skill;
                    }

                    if (!totalSkill.ContainsKey(name))
                    {
                        totalSkill.Add(name, 0);
                    }
                }

                foreach (var player in players)
                {
                    foreach (var possition in player.Value)
                    {
                        totalSkill[player.Key] = 0;
                    }
                }

                foreach (var player in players)
                {
                    foreach (var possition in player.Value)
                    {
                        totalSkill[player.Key] += possition.Value;
                    }
                }

                if (separator == " vs ")
                {
                    string player1 = inputArgs[0];
                    string player2 = inputArgs[1];

                    if (players.ContainsKey(player1) && players.ContainsKey(player2))
                    {
                        if (players[player1].Any(x => players[player2].Any(y => x.Key == y.Key)))
                        {
                            if (totalSkill[player1] > totalSkill[player2])
                            {
                                players.Remove(player2);
                                totalSkill.Remove(player2);
                            }
                            else if (totalSkill[player1] < totalSkill[player2])
                            {
                                players.Remove(player1);
                                totalSkill.Remove(player1);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var player in totalSkill.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value} skill");
                foreach (var possition in players[player.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {possition.Key} <::> {possition.Value}");
                }
            }
        }
    }
}
