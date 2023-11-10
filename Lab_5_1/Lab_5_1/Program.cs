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

                // створення об'єктів класу User
                User user1 = new User
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Doe",
                    Email = "johndoe@example.com"
                };
                User user2 = new User
                {
                    Id = 2,
                    Name = "Jane",
                    Surname = "Doe",
                    Email = "janedoe@example.com"
                };
                User user3 = new User
                {
                    Id = 3,
                    Name = "Peter",
                    Surname = "Smith",
                    Email = "petersmith@example.com"
                };
                // збереження об'єктів у базу даних
                db.Users.AddRange(user1, user2, user3);
                db.SaveChanges();
            }
            // отримання даних з бази даних
            using (Aplication db = new Aplication())
            {
                var _users = db.Users.ToList();
                Console.WriteLine("Список користувачів");
                foreach (User u in _users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}.{u.Surname}.{u.Email}");
                }
            }
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
        }
        public class Aplication : DbContext
        {
            public DbSet<User> Users { get; set; } = null;
            public Aplication()
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=3514;database=userdb;",
                    new MySqlServerVersion(new Version(8, 0, 35)));
            }
        }
    }
}
