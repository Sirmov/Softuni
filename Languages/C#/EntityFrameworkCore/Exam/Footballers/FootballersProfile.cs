namespace Footballers
{
    using AutoMapper;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using System;
    using System.Globalization;

    public class FootballersProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public FootballersProfile()
        {
            // Coaches
            CreateMap<CoachImportDto, Coach>()
                .ForMember(dest => dest.Footballers, opt => opt.Ignore());

            // Footballers
            CreateMap<FootballerImportDto, Footballer>()
                .ForMember(dest => dest.ContractStartDate, opt => opt
                    .MapFrom(src => DateTime.ParseExact(src.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.ContractEndDate, opt => opt
                    .MapFrom(src => DateTime.ParseExact(src.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.PositionType, opt => opt
                    .MapFrom(src => (PositionType) src.PositionType))
                .ForMember(dest => dest.BestSkillType, opt => opt
                    .MapFrom(src => (BestSkillType) src.BestSkillType));

            // Teams
            CreateMap<TeamImportDto, Team>();
        }
    }
}
