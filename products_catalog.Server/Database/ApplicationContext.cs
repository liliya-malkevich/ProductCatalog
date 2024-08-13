using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using products_catalog.Server.Models;
using System.Data;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "admin"
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = "advancedUser"
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Name = "user"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                PswdHash = "12345678Qq",
                RoleId =  1,
                Email = "admin@gmail.com"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                PswdHash = "12345678Qq1",
                RoleId = 2,
                Email = "advancedUser@gmail.com"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                PswdHash = "12345678Qq11",
                RoleId = 3,
                Email = "user@gmail.com"
            });

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
