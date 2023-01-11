namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var coachDtos = XmlConverter.Deserializer<CoachImportDto>(xmlString, "Coaches");
            var validCoaches = new List<Coach>();
            StringBuilder output = new StringBuilder();

            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                    Footballers = new HashSet<Footballer>()
                };

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto) ||
                        !Enum.IsDefined(typeof(PositionType), footballerDto.PositionType) ||
                        !Enum.IsDefined(typeof(BestSkillType), footballerDto.BestSkillType))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footballer = Mapper.Map<Footballer>(footballerDto);

                    // To do off by 1 error
                    if (footballer.ContractStartDate >= footballer.ContractEndDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    coach.Footballers.Add(footballer);
                }
                
                output.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
                validCoaches.Add(coach);
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamDtos = JsonConvert.DeserializeObject<TeamImportDto[]>(jsonString);
            var validTeams = new HashSet<Team>();
            int[] footballerIds = context.Footballers.Select(f => f.Id).ToArray();
            StringBuilder output = new StringBuilder();

            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto) ||
                    teamDto.Trophies <= 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies,
                    TeamsFootballers = new HashSet<TeamFootballer>()
                };

                foreach (var footballerId in teamDto.Footballers.Distinct())
                {
                    if (!footballerIds.Contains(footballerId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var teamFootballer = new TeamFootballer()
                    {
                        FootballerId = footballerId,
                        Team = team
                    };

                    team.TeamsFootballers.Add(teamFootballer);
                }

                validTeams.Add(team);
                output.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
