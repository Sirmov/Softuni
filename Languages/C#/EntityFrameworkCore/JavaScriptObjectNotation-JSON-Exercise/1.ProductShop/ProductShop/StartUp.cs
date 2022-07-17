using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var dbContext = new ProductShopContext())
            {
                // Test importing data
                
                //var usersJson = File.ReadAllText("Datasets/users.json");
                //Console.WriteLine(ImportUsers(dbContext, usersJson));

                //var productsJson = File.ReadAllText("Datasets/products.json");
                //Console.WriteLine(ImportProducts(dbContext, productsJson));

                //var categoriesJson = File.ReadAllText("Datasets/categories.json");
                //Console.WriteLine(ImportCategories(dbContext, categoriesJson));

                //var categoriesProductsJson = File.ReadAllText("Datasets/categories-products.json");
                //Console.WriteLine(ImportCategoryProducts(dbContext, categoriesProductsJson));
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
    }
}