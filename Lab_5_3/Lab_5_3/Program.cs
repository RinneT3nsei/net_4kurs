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

                // створення об'єктів класу Task
                Task task1 = new Task
                {
                    Id = 1,
                    Title = "Вiдправити лист",
                    Description = "Написати i вiдправити лист клiєнту",
                    Status = TaskStatus.InProcess
                };
                Task task2 = new Task
                {
                    Id = 2,
                    Title = "Зробити презентацiю",
                    Description = "Пiдготувати i провести презентацiю для клiєнта",
                    Status = TaskStatus.Completed
                };
                Task task3 = new Task
                {
                    Id = 3,
                    Title = "Написати статтю",
                    Description = "Написати статтю для блогу",
                    Status = TaskStatus.Rejected
                };
                // збереження об'єктів у базу даних
                db.Tasks.AddRange(task1, task2, task3);
                db.SaveChanges();
            }
            // отримання даних з бази даних
            using (Aplication db = new Aplication())
            {
                var _tasks = db.Tasks.ToList();
                Console.WriteLine("Список завдань");
                foreach (Task u in _tasks)
                {
                    Console.WriteLine($"{u.Id}.{u.Title}.{u.Description}.{u.Status}");
                }
            }
        }

        public enum TaskStatus
        {
            InProcess,
            Completed,
            Rejected
        }

        public class Task
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public TaskStatus Status { get; set; }
        }
        public class Aplication : DbContext
        {
            public DbSet<Task> Tasks { get; set; } = null;
            public Aplication()
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=3514;database=tasksdb;",
                    new MySqlServerVersion(new Version(8, 0, 35)));
            }
        }
    }
}
