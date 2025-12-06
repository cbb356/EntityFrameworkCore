/*
 * Використовуючи Visual Studio, створіть проєкт за шаблоном Console Application. 
 * Потрібно: Інсталюйте необхідні пакети для роботи з Entity Framework 
 * Створіть контекст бази даних MyDatabaseContext та, використовуючи матеріали завдання 1 (цього уроку), 
 * перенесіть ваш список у якості колекції DbSet, виконайте міграцію Заповніть таким самим способом, 
 * що і в першому завданні, через контекст MyDatabaseContext вашу колекцію тими самими значеннями. 
 * Переконайтесь, що дані збереглись у базу. Знайти та вивести > 1, 5, 0, 7 
 * з Product/User/Order (ваш варінт) контексту за ім’ям
 */

using Microsoft.EntityFrameworkCore;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDatabaseContext())
            {
                // Delete old data
                context.Orders.ExecuteDelete();
                // Add data
                Console.WriteLine("Seeding database with initial data...");
                context.Orders.AddRange(
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order01",
                        Create = new DateTime(2025, 11, 15, 10, 0, 0),
                        Update = new DateTime(2025, 11, 15, 10, 0, 0),
                        Description = "Goods"
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order02",
                        Create = new DateTime(2025, 11, 18, 14, 30, 0),
                        Update = new DateTime(2025, 11, 20, 9, 15, 0),
                        Description = "Software."
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order03",
                        Create = new DateTime(2025, 11, 19, 9, 0, 0),
                        Update = null,
                        Description = "Materials"
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order04",
                        Create = new DateTime(2025, 11, 21, 11, 45, 0),
                        Update = new DateTime(2025, 11, 25, 16, 0, 0),
                        Description = "Monitors"
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order05",
                        Create = new DateTime(2025, 11, 22, 16, 20, 0),
                        Update = null,
                        Description = null
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order06",
                        Create = new DateTime(2025, 11, 25, 8, 0, 0),
                        Update = new DateTime(2025, 11, 25, 13, 0, 0),
                        Description = "Custom tools"
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order07",
                        Create = new DateTime(2025, 11, 26, 17, 10, 0),
                        Update = new DateTime(2025, 12, 1, 11, 0, 0),
                        Description = "Service"
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order08",
                        Create = new DateTime(2025, 11, 28, 9, 30, 0),
                        Update = null,
                        Description = "Tools"
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order09",
                        Create = new DateTime(2025, 12, 2, 13, 0, 0),
                        Update = new DateTime(2025, 12, 3, 10, 0, 0),
                        Description = "Software"
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Name = "Order10",
                        Create = new DateTime(2025, 12, 3, 15, 0, 0),
                        Update = null,
                        Description = null
                    }
                );
                context.SaveChanges();
                Console.WriteLine("Data saved successfully.\n");

                //Show orders by name
                ShowByName(context, "Order02");
                ShowByName(context, "Order06");
                ShowByName(context, "Order01");
                ShowByName(context, "Order08");
                ShowByName(context, "NonExistentOrder");
            }
            // Delay.
            Console.ReadKey();
        }


        public static void ShowByName(MyDatabaseContext db, string name)
        {
            try
            {
                Order? order = db.Orders.FirstOrDefault(x => x.Name == name);
                if (order != null)
                {
                    Console.WriteLine($"The order with Name {name}:\n{order.ToString()}");
                }
                else
                {
                    Console.WriteLine($"The order with Name {name} was not found\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding order for Name {name}: {ex.Message}\n");
            }
        }
    }
}
