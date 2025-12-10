using ErrorFluentApi.Entities;

namespace ErrorFluentApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDatabaseContext())
            {
                Console.WriteLine("Seeding database with initial data...");
                context.Orders.AddRange(
                    new Order { OrderId = Guid.NewGuid(), Name = "Order01", Create = new DateTime(2025, 11, 15, 10, 0, 0), Update = new DateTime(2025, 11, 15, 10, 0, 0), Description = "Goods"},
                    new Order { OrderId = Guid.NewGuid(), Name = "Order02", Create = new DateTime(2025, 11, 18, 14, 30, 0), Update = new DateTime(2025, 11, 20, 9, 15, 0), Description = "Software."},
                    new Order { OrderId = Guid.NewGuid(), Name = "Order03", Create = new DateTime(2025, 11, 19, 9, 0, 0), Update = null, Description = "Materials"},
                    new Order { OrderId = Guid.NewGuid(), Name = "Order04", Create = new DateTime(2025, 11, 21, 11, 45, 0), Update = new DateTime(2025, 11, 25, 16, 0, 0), Description = "Monitors" },
                    new Order { OrderId = Guid.NewGuid(), Name = "Order05", Create = new DateTime(2025, 11, 22, 16, 20, 0), Update = null, Description = null},
                    new Order { OrderId = Guid.NewGuid(), Name = "Order06", Create = new DateTime(2025, 11, 25, 8, 0, 0), Update = new DateTime(2025, 11, 25, 13, 0, 0), Description = "Custom tools" },
                    new Order { OrderId = Guid.NewGuid(), Name = "Order07", Create = new DateTime(2025, 11, 26, 17, 10, 0), Update = new DateTime(2025, 12, 1, 11, 0, 0), Description = "Service" },
                    new Order { OrderId = Guid.NewGuid(), Name = "Order08", Create = new DateTime(2025, 11, 28, 9, 30, 0), Update = null, Description = "Tools" },
                    new Order { OrderId = Guid.NewGuid(), Name = "Order09", Create = new DateTime(2025, 12, 2, 13, 0, 0), Update = new DateTime(2025, 12, 3, 10, 0, 0), Description = "Software"},
                    new Order { OrderId = Guid.NewGuid(), Name = "Order10", Create = new DateTime(2025, 12, 3, 15, 0, 0), Update = null, Description = null }
                );
                context.SaveChanges();
                Console.WriteLine("Data saved successfully.\n");

                var errors = new List<Error>();

                try
                {
                    Console.WriteLine("Attempting to fetch an invalid order...");

                    var invalidOrder = context.Orders
                        .Skip(-1)
                        .FirstOrDefault(); ;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception caught: {ex.Message}");

                    // Populate the Error collection
                    var errorLog = new Error
                    {
                        Message = ex.Message,
                        Time = DateTime.Now,
                        Request = "Get Order by Name 'NonExistentItem'",
                        Status = StatusCode.NotFound // 400
                    };

                    errors.Add(errorLog);

                    Console.WriteLine("\nError added to context collection.");
                    Console.WriteLine($"Logged Error: [{errorLog.Time}] {errorLog.Status} - {errorLog.Message}");
                }

                Console.WriteLine($"\nErrors in local memory: {errors.Count}");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
