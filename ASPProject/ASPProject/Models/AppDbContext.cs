using ASPProject.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models
{
    public class AppDbContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <ProductDetails> ProductsDetails { get; set; } 
        public DbSet <OrderProduct> OrderProduct { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });

            builder.Entity<Product>()
                .HasOne(x => x.Details)
                .WithOne(x => x.Product);

            builder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category);

            builder.Entity<Order>()
                .HasOne(x => x.User)
                .WithMany(x => x.Order);

            builder.Entity<OrderProduct>(op =>
                    {
                        op.HasKey(op => new { op.OrderId, op.ProductId });

                        op.HasOne(op => op.Order).WithMany(o => o.OrderProduct).HasForeignKey(op => op.OrderId);
                        op.HasOne(op => op.Product).WithMany(p => p.OrderProduct).HasForeignKey(op => op.ProductId);
                    }
                );

        }

       
    }
}
