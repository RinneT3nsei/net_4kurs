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
            using(Aplication db = new Aplication()) 
            {

                Book book1 = new Book
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    Description = "A novel by F. Scott Fitzgerald",
                    Author = "F. Scott Fitzgerald"
                };
                Book book2 = new Book
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    Description = "A novel by Harper Lee",
                    Author = "Harper Lee"
                };
                Book book3 = new Book
                {
                    Id = 3,
                    Title = "1984",
                    Description = "A novel by George Orwell",
                    Author = "George Orwell"
                };
                db.Books.AddRange(book1, book2, book3);
                db.SaveChanges();
            }
            // получение данных
            using (Aplication db = new Aplication()) 
            {
                var _books = db.Books.ToList();
                Console.WriteLine("Список Об'єктiв");
                foreach (Book u in _books)
                {
                    Console.WriteLine($"{u.Id}.{u.Title}.{u.Description}.{u.Author}");
                }
            }
        }
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Author { get; set; }
        }
        public class Aplication : DbContext
        {
            public DbSet<Book> Books { get; set; } = null;
            public Aplication() 
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=3514;database=librarydb;",
                    new MySqlServerVersion(new Version(8, 0, 35)));
            }
        }
    }
}