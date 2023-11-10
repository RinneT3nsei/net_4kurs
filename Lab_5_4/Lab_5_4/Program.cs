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

                Contact contact1 = new Contact
                {
                    Id = 1,
                    Name = "John Doe",
                    PhoneNumber = "+380991234567",
                    Address = "Kyiv, Ukraine"
                };
                Contact contact2 = new Contact
                {
                    Id = 2,
                    Name = "Jane Doe",
                    PhoneNumber = "+380992345678",
                    Address = "Lviv, Ukraine"
                };
                Contact contact3 = new Contact
                {
                    Id = 3,
                    Name = "John Smith",
                    PhoneNumber = "+380993456789",
                    Address = "Odessa, Ukraine"
                };
                db.Contacts.AddRange(contact1, contact2, contact3);
                db.SaveChanges();
            }
            // отримання даних
            using (Aplication db = new Aplication())
            {
                var _contacts = db.Contacts.ToList();
                Console.WriteLine("Список Об'єктiв");
                foreach (Contact u in _contacts)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}.{u.PhoneNumber}.{u.Address}");
                }
            }
            // додавання нового контакту
            using (Aplication db = new Aplication())
            {
                Contact newContact = new Contact
                {
                    Name = "New Contact",
                    PhoneNumber = "+380994567890",
                    Address = "Kharkiv, Ukraine"
                };
                db.Contacts.Add(newContact);
                db.SaveChanges();
            }
            // оновлення контакту
            using (Aplication db = new Aplication())
            {
                Contact contact = db.Contacts.Find(2);
                contact.Name = "Updated Contact";
                contact.PhoneNumber = "+380995678901";
                contact.Address = "Dnipro, Ukraine";
                db.SaveChanges();
            }
            // видалення контакту
            using (Aplication db = new Aplication())
            {
                Contact contact = db.Contacts.Find(3);
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }
        public class Contact
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
        }
        public class Aplication : DbContext
        {
            public DbSet<Contact> Contacts { get; set; } = null;
            public Aplication()
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=3514;database=contactdb;",
                    new MySqlServerVersion(new Version(8, 0, 35)));
            }
        }
    }
}
