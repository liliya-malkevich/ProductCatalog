using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using products_catalog.Server.Models;
using System.Reflection.Metadata;

namespace products_catalog.Server.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            //CategoryItem category1 = new CategoryItem{Name = "Еда" };
            //CategoryItem category2 = new CategoryItem { Name = "Вкусности" };
            //CategoryItem category3 = new CategoryItem { Name = "Вода" };
            //Product product1 = new Product { Name = "Селедка соленая", CategoryItemId = 1,Price = "10000",Note = "Акция",NoteSpec = "Пересоленая",Description = "Селедка соленая" };
            //Product product2 = new Product {  };
            //Product product3 = new Product {  };
            //Product product4 = new Product {  };
        
        }
        public DbSet<CategoryItem> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryItem>().HasData(new CategoryItem
            {
                Id = 1,
                Name = "Еда"
            });
            modelBuilder.Entity<CategoryItem>().HasData(new CategoryItem
            {
                Id = 2,
                Name = "Вкусности"
            });
            modelBuilder.Entity<CategoryItem>().HasData(new CategoryItem
            {
                Id = 3,
                Name = "Вода"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Селедка соленая",
                CategoryItemId = 1,
                Price = "10000",
                Note = "Акция",
                NoteSpec = "Пересоленая",
                Description = "Селедка соленая"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Тушенка говяжья",
                CategoryItemId = 1,
                Price = "20000",
                Note = "Вкусная",
                NoteSpec = "Жилы",
                Description = "Тушенка говяжья"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Сгущенка",
                CategoryItemId = 2,
                Price = "30000",
                Note = "С ключом",
                NoteSpec = "Вкусная",
                Description = "В банках"

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Вода",
                CategoryItemId = 3,
                Price = "15000",
                Note = "Вятский",
                NoteSpec = "Теплый",
                Description = "В бутылках"
            });
        }
    }
}
