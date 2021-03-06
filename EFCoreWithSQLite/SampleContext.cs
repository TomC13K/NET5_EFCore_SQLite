﻿using Microsoft.EntityFrameworkCore;

namespace EFCoreWithSQLite
{
    public class SampleContext:DbContext
    {
        public SampleContext()
        {
            this.Database.EnsureCreated();          //if db doesnt exist it will create it
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Filename=./test.sqlite");
        }

        public DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
