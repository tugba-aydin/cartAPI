using cartAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cartAPI.Data
{
    public class MyDBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Role> Roles { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Cart>().ToTable("Carts");
            modelBuilder.Entity<Role>().ToTable("Roles");


            // Configure Primary Keys  
            modelBuilder.Entity<Product>().HasKey(p => p.Id).HasName("PK_Products");
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_Users");
            modelBuilder.Entity<Cart>().HasKey(c => c.Id).HasName("PK_Carts");
            modelBuilder.Entity<Role>().HasKey(r => r.Id).HasName("PK_Roles");


            // Configure columns  
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Photo).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("double").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Stock).HasColumnType("int").IsRequired();

            modelBuilder.Entity<Role>().Property(r => r.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Role>().Property(r => r.Name).HasColumnType("nvarchar(50)").IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.UserName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.RoleId).HasColumnType("int").IsRequired();

            modelBuilder.Entity<Cart>().Property(c => c.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Cart>().Property(c => c.Quantity).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Cart>().Property(c => c.ProductId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Cart>().Property(c => c.ProductName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Cart>().Property(c => c.ProductPhoto).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<Cart>().Property(c => c.ProductPrice).HasColumnType("double").IsRequired();
            modelBuilder.Entity<Cart>().Property(c => c.ProductStock).HasColumnType("int").IsRequired();

            // Configure relationships  
        }

    }
}
