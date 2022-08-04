using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
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
                //dbContext.Database.EnsureDeleted();
                //dbContext.Database.EnsureCreated();

                //Testing importing data
                //string usersXml = File.ReadAllText("Datasets/users.xml");
                //Console.WriteLine(ImportUsers(dbContext, usersXml));

                //string productsXml = File.ReadAllText("Datasets/products.xml");
                //Console.WriteLine(ImportProducts(dbContext, productsXml));

                //string categoriesXml = File.ReadAllText("Datasets/categories.xml");
                //Console.WriteLine(ImportCategories(dbContext, categoriesXml));

                //string categoryProductsXml = File.ReadAllText("Datasets/categories-products.xml");
                //Console.WriteLine(ImportCategoryProducts(dbContext, categoryProductsXml));

                // Test exporting data
                //string productsInRangeXml = GetProductsInRange(dbContext);
                //File.WriteAllText("../../../Exports/products-in-range.xml", productsInRangeXml);

                //string soldProductsXml = GetSoldProducts(dbContext);
                //File.WriteAllText("../../../Exports/users-sold-products.xml", soldProductsXml);

                //string categories = GetCategoriesByProductsCount(dbContext);
                //File.WriteAllText("../../../Exports/categories-by-products.xml", categories);

                string usersProducts = GetUsersWithProducts(dbContext);
                File.WriteAllText("../../../Exports/users-and-products.xml", usersProducts);
            }
        }

        // Exporting data

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .ThenInclude(ps => ps.Buyer)
                .AsEnumerable()
                .Where(u => u.ProductsSold.Count(ps => ps.BuyerId.HasValue) > 0)
                .Select(u => new UserProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsDto()
                    {
                        Count = u.ProductsSold.Where(ps => ps.BuyerId.HasValue).Count(),
                        Products = u.ProductsSold
                            .Where(ps => ps.BuyerId.HasValue)
                            .Select(ps => new SoldProductDto()
                            {
                                Name = ps.Name,
                                Price = (double) ps.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            var xmlObject = new UsersWithProductsDto()
            {
                Count = users.Length,
                Users = users.Take(10).ToArray()
            };

            string serializedXml = XmlConverter.Serialize(xmlObject, "Users");

            return serializedXml;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Include(c => c.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .ProjectTo<CategoryProductsDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.ProductsCount)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            string serializedXml = XmlConverter.Serialize(categories, "Categories");

            return serializedXml;
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
               .Take(5)
               .ToList();

            string serializedXml = XmlConverter.Serialize(users, "Users");

            return serializedXml;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Include(p => p.Buyer)
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .ProjectTo<ProductPriceRangeDto>(mapper.ConfigurationProvider)
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            string serializedXml = XmlConverter.Serialize(products, "Products");

            return serializedXml;
        }

        // Importing data

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            int[] categoryIds = context.Categories.Select(c => c.Id).ToArray();
            int[] productIds = context.Products.Select(p => p.Id).ToArray();

            var categoryProducts = XmlConverter.Deserializer<ImportCategoryProductDto>(inputXml, "CategoryProducts")
                .Where(dto => categoryIds.Contains(dto.CategoryId))
                .Where(dto => productIds.Contains(dto.ProductId))
                .Select(dto => mapper.Map<CategoryProduct>(dto))
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categories = XmlConverter.Deserializer<ImportCategoryDto>(inputXml, "Categories")
                .Where(dto => dto.Name != null)
                .Select(dto => mapper.Map<Category>(dto))
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            int[] userIds = context.Users.Select(u => u.Id).ToArray();

            var products = XmlConverter.Deserializer<ImportProductDto>(inputXml, "Products")
                .Where(dto => userIds.Contains(dto.BuyerId))
                .Select(dto => mapper.Map<Product>(dto))
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

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