using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();

            while (input != "End")
            {
                string[] soldierInfo = input.Split();
                string soldierType = soldierInfo[0];
                string id = soldierInfo[1];
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);
                    soldiers.Add(id, new Private(id, firstName, lastName, salary));
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);
                    string[] privateIds = soldierInfo.Skip(5).ToArray();
                    List<Private> squad = new List<Private>();

                    foreach (var privateId in privateIds)
                    {
                        if (soldiers.ContainsKey(privateId))
                        {
                            squad.Add((Private) soldiers[privateId]);
                        }
                    }

                    soldiers.Add(id, new LieutenantGeneral(id, firstName, lastName, salary, squad.ToArray()));
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);
                    string corps = soldierInfo[5];
                    string[] repairsInfo = soldierInfo.Skip(6).ToArray();
                    List<Repair> repairs = new List<Repair>();

                    for (int i = 0; i < repairsInfo.Length; i += 2)
                    {
                        string partName = repairsInfo[i];
                        int repairHours = int.Parse(repairsInfo[i + 1]);

                        repairs.Add(new Repair(partName, repairHours));
                    }

                    try
                    {
                        soldiers.Add(id, new Engineer(id, firstName, lastName, salary, corps, repairs.ToArray()));
                    }
                    catch (Exception e)
                    {

                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);
                    string corps = soldierInfo[5];
                    string[] missionsInfo = soldierInfo.Skip(6).ToArray();
                    List<Mission> missions = new List<Mission>();

                    for (int i = 0; i < missionsInfo.Length; i += 2)
                    {
                        string codeName = missionsInfo[i];
                        string state = missionsInfo[i + 1];

                        try
                        {
                            missions.Add(new Mission(codeName, state));
                        }
                        catch (Exception e)
                        {

                        }
                    }

                    try
                    {
                        soldiers.Add(id, new Commando(id, firstName, lastName, salary, corps, missions.ToArray()));
                    }
                    catch (Exception e)
                    {

                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(soldierInfo[4]);
                    soldiers.Add(id, new Spy(id, firstName, lastName, codeNumber));
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
