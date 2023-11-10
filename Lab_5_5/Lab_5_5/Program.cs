using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{

    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string TableNumber { get; set; }
        public List<OrderItem> Items { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public void AddItem(string dishName, int quantity, double price)
        {
            Items.Add(new OrderItem
            {
                DishName = dishName,
                Quantity = quantity,
                Price = price
            });
        }
    }

    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public string DishName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class Aplication : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null;
        public DbSet<OrderItem> OrderItems { get; set; } = null;

        public Aplication()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=3514;database=restaurantdb;",
                new MySqlServerVersion(new Version(8, 0, 35)));
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
            SaveChanges();
        }

        public IEnumerable<Order> GetOrders()
        {
            return Orders.Include(o => o.Items).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (Aplication db = new Aplication())
            {
                // додавання нового замовлення
                Order order = new Order
                {
                    CustomerName = "John Doe",
                    TableNumber = "1",
                };
                order.AddItem("Pizza", 2, 20.0);
                order.AddItem("Steak", 1, 50.0);
                db.AddOrder(order);

                // вивід історії замовлень
                var orders = db.GetOrders();
                foreach (Order o in orders)
                {
                    Console.WriteLine($"Замовлення №{o.Id} вiд {o.CustomerName}");
                    foreach (OrderItem i in o.Items)
                    {
                        Console.WriteLine($"\t{i.DishName}: {i.Quantity} шт. по {i.Price} грн.");
                    }
                }
            }
        }
    }
}
