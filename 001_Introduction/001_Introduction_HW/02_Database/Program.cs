/*
 * Використовуючи Visual Studio, створіть проєкт за шаблоном Console Application. 
 * Потрібно: Інсталюйте необхідні пакети для роботи з Entity Framework 
 * Створіть контекст бази даних MyDatabaseContext та, використовуючи матеріали завдання 1 (цього уроку), 
 * перенесіть ваш список у якості колекції DbSet, виконайте міграцію Заповніть таким самим способом, 
 * що і в першому завданні, через контекст MyDatabaseContext вашу колекцію тими самими значеннями. 
 * Переконайтесь, що дані збереглись у базу. Знайти та вивести > 1, 5, 0, 7 
 * з Product/User/Order (ваш варінт) контексту за ім’ям
 */

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDatabaseContext())
            {
                if (!context.Orders.Any())
                {
                    Console.WriteLine("Seeding database with initial data...");
                    context.Orders.AddRange(
                        new Order
                        {
                            Id = Guid.Parse("EABD694D-E41B-40F8-BF78-289868E9FAD5"),
                            Name = "Order01",
                            Create = new DateTime(2025, 11, 15, 10, 0, 0),
                            Update = new DateTime(2025, 11, 15, 10, 0, 0),
                            Description = "Goods"
                        },
                        new Order
                        {
                            Id = Guid.Parse("7B0301AF-02E5-43B3-B94C-A7E4F5418BE3"),
                            Name = "Order02",
                            Create = new DateTime(2025, 11, 18, 14, 30, 0),
                            Update = new DateTime(2025, 11, 20, 9, 15, 0),
                            Description = "Software."
                        },
                        new Order
                        {
                            Id = Guid.Parse("646D8590-B84F-4428-9276-30479E857843"),
                            Name = "Order03",
                            Create = new DateTime(2025, 11, 19, 9, 0, 0),
                            Update = null,
                            Description = "Materials"
                        },
                        new Order
                        {
                            Id = Guid.Parse("E1A98A97-EF71-4CC7-9EC6-2CA7E2D7D31F"),
                            Name = "Order04",
                            Create = new DateTime(2025, 11, 21, 11, 45, 0),
                            Update = new DateTime(2025, 11, 25, 16, 0, 0),
                            Description = "Monitors"
                        },
                        new Order
                        {
                            Id = Guid.Parse("6D403881-F8CE-4D74-9BA5-2D17BC630058"),
                            Name = "Order05",
                            Create = new DateTime(2025, 11, 22, 16, 20, 0),
                            Update = null,
                            Description = null
                        },
                        new Order
                        {
                            Id = Guid.Parse("8999AD9D-5CA8-47E1-A14D-16D397AE0BF8"),
                            Name = "Order06",
                            Create = new DateTime(2025, 11, 25, 8, 0, 0),
                            Update = new DateTime(2025, 11, 25, 13, 0, 0),
                            Description = "Custom tools"
                        },
                        new Order
                        {
                            Id = Guid.Parse("E65CDF84-1D15-4B1C-BCA8-7507AEA951D2"),
                            Name = "Order07",
                            Create = new DateTime(2025, 11, 26, 17, 10, 0),
                            Update = new DateTime(2025, 12, 1, 11, 0, 0),
                            Description = "Service"
                        },
                        new Order
                        {
                            Id = Guid.Parse("174124FA-E340-4763-8DD3-E721ACE0420D"),
                            Name = "Order08",
                            Create = new DateTime(2025, 11, 28, 9, 30, 0),
                            Update = null,
                            Description = "Tools"
                        },
                        new Order
                        {
                            Id = Guid.Parse("A8FED3C6-F018-4869-A3D7-4BBFBDB4E186"),
                            Name = "Order09",
                            Create = new DateTime(2025, 12, 2, 13, 0, 0),
                            Update = new DateTime(2025, 12, 3, 10, 0, 0),
                            Description = "Software"
                        },
                        new Order
                        {
                            Id = Guid.Parse("51ABE043-5FED-4C0D-9F27-ECA5D8A48A6B"),
                            Name = "Order10",
                            Create = new DateTime(2025, 12, 3, 15, 0, 0),
                            Update = null,
                            Description = null
                        }
                    );
                    context.SaveChanges();
                    Console.WriteLine("Data saved successfully.\n");
                }
                else
                {
                    Console.WriteLine("Database already contains data. Skipping insertion.\n");
                }
                 
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
