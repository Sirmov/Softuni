using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        // Newtonsoft Json Configuration

        private static DefaultContractResolver defaultContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };

        private static JsonSerializerSettings defaultJsonSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = defaultContractResolver,
            Formatting = Formatting.Indented
        };

        private static JsonSerializerSettings ingnoreNullJsonSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = defaultContractResolver,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
        };

        // Mapper Configuration

        private static MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
        {
            config.AddProfile(new CarDealerProfile());
        });

        private static IMapper mapper = mapperConfiguration.CreateMapper();

        public static void Main(string[] args)
        {
            using (var dbContex = new CarDealerContext())
            {
                // Testing importing data

                //string suppliersJson = File.ReadAllText("Datasets/suppliers.json");
                //Console.WriteLine(ImportSuppliers(dbContex, suppliersJson));

                //string partsJson = File.ReadAllText("Datasets/parts.json");
                //Console.WriteLine(ImportParts(dbContex, partsJson));

                //string carsJson = File.ReadAllText("Datasets/cars.json");
                //Console.WriteLine(ImportCars(dbContex, carsJson));

                //string customersJson = File.ReadAllText("Datasets/customers.json");
                //Console.WriteLine(ImportCustomers(dbContex, customersJson));

                //string salesJson = File.ReadAllText("Datasets/sales.json");
                //Console.WriteLine(ImportSales(dbContex, salesJson));
            }
        }

        // Importing data

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDtos = JsonConvert.DeserializeObject<List<CarImportDto>>(inputJson);
            List<Car> cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                Car car = mapper.Map<Car>(carDto);

                foreach (int partId in carDto.PartsId.Distinct())
                {
                    if (context.Parts.Any(p => p.Id == partId))
                    {
                        PartCar partCar = new PartCar()
                        {
                            CarId = car.Id,
                            PartId = partId
                        };

                        car.PartCars.Add(partCar);
                    }
                }

                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();
            
            return $"Successfully imported {carDtos.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
    }
}