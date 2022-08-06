namespace Artillery
{
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    using System;
    using System.Linq;

    class ArtilleryProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public ArtilleryProfile()
        {
            // Countries
            CreateMap<CountryImportDto, Country>();

            // Manufacturers
            CreateMap<ManufacturerImportDto, Manufacturer>()
                .ForMember(dest => dest.Founded, opt => opt
                    .MapFrom(src => string.Join(", ", src.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries).TakeLast(2))));

            // Shells
            CreateMap<ShellImportDto, Shell>();

            // Guns
            CreateMap<GunImportDto, Gun>()
                .ForMember(dest => dest.GunType, opt => opt
                    .MapFrom(src => Enum.Parse<GunType>(src.GunType)));
        }
    }
}