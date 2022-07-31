using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        // Mapper Configuration

        private static MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
        {
            config.AddProfile(new ProductShopProfile());
        });

        private static IMapper mapper = mapperConfiguration.CreateMapper();

        public static void Main(string[] args)
        {
            using (var dbContext = new ProductShopContext())
            {
                // Testing importing data
                string usersXml = File.ReadAllText("users.xml");
                Console.WriteLine(ImportUsers(dbContext, usersXml));
            }
        }

        // Importing data

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var users = XmlConverter.Deserializer<ImportUserDto>(inputXml, "Users")
                .Select(dto => mapper.Map<User>(dto))
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}