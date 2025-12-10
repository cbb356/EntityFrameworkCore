using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorFluentApi.Entities
{
    internal class MyDatabaseContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public MyDatabaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=TestDB;Integrated Security=True;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add composite key    
            modelBuilder.Entity<Order>()
                .HasKey(o => new { o.OrderId, o.OrderAlterId });

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderAlterId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .Property(o => o.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.Create)
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.Update)
                .HasColumnType("date");

            modelBuilder.Entity<Order>()
                .Property(o => o.Description)
                .HasMaxLength(400);

            modelBuilder.Ignore<Error>();
        }
    }
}
