using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    internal class MyDatabaseContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public MyDatabaseContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=TestDB;Integrated Security=True;Trust Server Certificate=True;");
        }
    }
}
