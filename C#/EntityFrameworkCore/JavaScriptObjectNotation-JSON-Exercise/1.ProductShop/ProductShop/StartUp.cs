﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
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
            config.AddProfile(new ProductShopProfile());
        });

        private static IMapper mapper = mapperConfiguration.CreateMapper();

        public static void Main(string[] args)
        {
            using (var dbContext = new ProductShopContext())
            {
                //Test importing data

                var usersJson = File.ReadAllText("Datasets/users.json");
                Console.WriteLine(ImportUsers(dbContext, usersJson));

                var productsJson = File.ReadAllText("Datasets/products.json");
                Console.WriteLine(ImportProducts(dbContext, productsJson));

                var categoriesJson = File.ReadAllText("Datasets/categories.json");
                Console.WriteLine(ImportCategories(dbContext, categoriesJson));

                var categoriesProductsJson = File.ReadAllText("Datasets/categories-products.json");
                Console.WriteLine(ImportCategoryProducts(dbContext, categoriesProductsJson));

                //Test exporting data

                var productsInRangeJson = GetProductsInRange(dbContext);
                File.WriteAllText("../../../Exports/products-in-range.json", productsInRangeJson);

                var usersSoldProducts = GetSoldProducts(dbContext);
                File.WriteAllText("../../../Exports/users-sold-products.json", usersSoldProducts);

                var categoriesProducts = GetCategoriesByProductsCount(dbContext);
                File.WriteAllText("../../../Exports/categories-by-products.json", categoriesProducts);

                var usersWithProducts = GetUsersWithProducts(dbContext);
                File.WriteAllText("../../../Exports/users-and-products.json", usersWithProducts);
            }
        }

        // Importing data
        
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // Exporting data

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Include(p => p.Seller)
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .ProjectTo<ProductPriceRangeDto>(mapper.ConfigurationProvider)
                .OrderBy(p => p.Price)
                .ToList();

            string serializedJson = JsonConvert.SerializeObject(products, defaultJsonSerializerSettings);

            return serializedJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .ThenInclude(ps => ps.Buyer)
                .Where(u => u.ProductsSold.Count(ps => ps.BuyerId.HasValue) > 0)
                .ProjectTo<UserSoldProductsDto>(mapper.ConfigurationProvider)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            string serializedJson = JsonConvert.SerializeObject(users, defaultJsonSerializerSettings);

            return serializedJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Include(c => c.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .ProjectTo<CategoryProductsDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.ProductsCount)
                .ToList();

            string serializedJson = JsonConvert.SerializeObject(categories, defaultJsonSerializerSettings);

            return serializedJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .ThenInclude(ps => ps.Buyer)
                .AsEnumerable()
                .Where(u => u.ProductsSold.Count(ps => ps.BuyerId.HasValue) > 0)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Where(ps => ps.BuyerId.HasValue).Count(),
                        Products = u.ProductsSold
                        .Where(ps => ps.BuyerId.HasValue)
                        .Select(ps => new
                        {
                            ps.Name,
                            ps.Price
                        })
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToList();

            var jsonObject = new { UsersCount = users.Count, Users = users};

            string serializedJson = JsonConvert.SerializeObject(jsonObject, ingnoreNullJsonSerializerSettings);

            return serializedJson;
        }
    }
}