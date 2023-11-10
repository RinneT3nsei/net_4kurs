using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Aplication db = new Aplication())
            {
                // додавання продукту
                Product product1 = new Product
                {
                    Id = 1,
                    Name = "iPhone 13 Pro Max",
                    Price = 1099.99,
                    Description = "The most advanced iPhone ever",
                    Category = "Mobile phones",
                    IsAvailable = true
                };
                Product product2 = new Product
                {
                    Id = 2,
                    Name = "iPhone 14 Pro Max",
                    Price = 1599.99,
                    Description = "The most advanced iPhone ever",
                    Category = "Mobile phones",
                    IsAvailable = true
                };
                Product product3 = new Product
                {
                    Id = 3,
                    Name = "iPhone 15 Pro Max",
                    Price = 2099.99,
                    Description = "The most advanced iPhone ever",
                    Category = "Mobile phones",
                    IsAvailable = true
                };
                db.Products.AddRange(product1, product2, product3);
                db.SaveChanges();

                // оновлення продукту
                Product product4 = db.Products.Find(1);
                product4.Price = 1199.99;
                db.UpdateProduct(product4);

                // видалення продукту
                Product product5 = db.Products.Find(2);
                int productId = product5.Id;

                if (productId != null)
                {
                    db.DeleteProduct(productId);
                }



                // отримання даних
                var products = db.Products.ToList();
                foreach (Product product in products)
                {
                    Console.WriteLine($"{product.Id}.{product.Name}.{product.Price}.{product.Description}.{product.Category}.{product.IsAvailable}");
                }
            }
        }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public bool IsAvailable { get; set; }
        }

        public class Aplication : DbContext
        {
            public DbSet<Product> Products { get; set; }

            public Aplication()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=3514;database=productdb;",
                    new MySqlServerVersion(new Version(8, 0, 35)));
            }

            public void AddProduct(Product product)
            {
                Products.Add(product);
                SaveChanges();
            }

            public void UpdateProduct(Product product)
            {
                Products.Update(product);
                SaveChanges();
            }

            public void DeleteProduct(int id)
            {
                Product product = Products.Find(id);
                Products.Remove(product);
                SaveChanges();
            }
        }
    }
}
