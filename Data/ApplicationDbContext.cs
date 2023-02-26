using AssignmentApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace AssignmentApp1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Categories = new List<Category>
    {
        new Category { Id = 1, Name = "Electronics", Products = new List<Product>() },
        new Category { Id = 2, Name = "Books", Products = new List<Product>() },
        new Category { Id = 3, Name = "Clothing", Products = new List<Product>() }
    };

            Products = new List<Product>
    {
        new Product { Id = 1, Name = "iPhone", Price = 1000.00M, CategoryId = 1 },
        new Product { Id = 2, Name = "Samsung Galaxy", Price = 800.00M, CategoryId = 1 },
        new Product { Id = 3, Name = "MacBook Pro", Price = 2000.00M, CategoryId = 1 },
        new Product { Id = 4, Name = "C# in Depth", Price = 50.00M, CategoryId = 2 },
        new Product { Id = 5, Name = "Clean Code", Price = 40.00M, CategoryId = 2 },
        new Product { Id = 6, Name = "Head First Design Patterns", Price = 60.00M, CategoryId = 2 },
        new Product { Id = 7, Name = "T-Shirt", Price = 20.00M, CategoryId = 3 },
        new Product { Id = 8, Name = "Jeans", Price = 50.00M, CategoryId = 3 },
        new Product { Id = 9, Name = "Jacket", Price = 100.00M, CategoryId = 3 }
    };

            foreach (var product in Products)
            {
                Categories.First(c => c.Id == product.CategoryId).Products.Add(product);
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyMockDatabase");
        }
    }
}
