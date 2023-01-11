namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Artillery.Data;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.DataProcessor;
    using System.Text;
    using Artillery.Data.Models;
    using AutoMapper;
    using Newtonsoft.Json;
    using Artillery.Data.Models.Enums;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var countryDtos = XmlConverter.Deserializer<CountryImportDto>(xmlString, "Countries");
            var validCountries = new List<Country>();
            StringBuilder output = new StringBuilder();

            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var country = Mapper.Map<Country>(countryDto);
                validCountries.Add(country);
                output.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var manufacturerDtos = XmlConverter.Deserializer<ManufacturerImportDto>(xmlString, "Manufacturers");
            var validManufacturers = new List<Manufacturer>();
            StringBuilder output = new StringBuilder();

            foreach (var manufacturerDto in manufacturerDtos)
            {
                if (!IsValid(manufacturerDto) || 
                    validManufacturers.Any(m => m.ManufacturerName == manufacturerDto.ManufacturerName))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = Mapper.Map<Manufacturer>(manufacturerDto);
                validManufacturers.Add(manufacturer);
                output.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, manufacturer.Founded));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var shellDtos = XmlConverter.Deserializer<ShellImportDto>(xmlString, "Shells");
            var validShells = new List<Shell>();
            StringBuilder output = new StringBuilder();

            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = Mapper.Map<Shell>(shellDto);
                validShells.Add(shell);
                output.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var gunDtos = JsonConvert.DeserializeObject<GunImportDto[]>(jsonString);
            var validGuns = new List<Gun>();
            StringBuilder output = new StringBuilder();

            foreach (var gunDto in gunDtos)
            {
                if (!IsValid(gunDto) || !Enum.TryParse<GunType>(gunDto.GunType, true, out _))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = Mapper.Map<Gun>(gunDto);

                foreach (var country in gunDto.Countries)
                {
                    var countryGun = new CountryGun()
                    {
                        CountryId = country.Id,
                        Gun = gun
                    };

                    gun.CountriesGuns.Add(countryGun);
                }

                validGuns.Add(gun);
                output.AppendLine(string.Format(SuccessfulImportGun, gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
