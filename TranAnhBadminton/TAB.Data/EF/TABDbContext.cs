using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Cofigurations;
using TAB.Data.Configurations;
using TAB.Data.Entities;
using TAB.Data.Extensions;

namespace TAB.Data.EF
{
    public class TABDbContext : IdentityDbContext<User, Role, Guid>
    {
        public TABDbContext(DbContextOptions options) : base(options)
        {
        }

        public TABDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SlideConfiguration());

            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillDetailConfiguration());

            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // base.OnModelCreating(modelBuilder);

            // Data Seeding
            modelBuilder.Seed();
        }

        public DbSet<Config> Configs { get; set; }

        // AppRoles + AppUser

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<BillDetail> BillDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Slide> Slides { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<ProductInCategory> ProductInCategories { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<PromotionDetail> PromotionDetails { get; set; }

        public DbSet<Role> Roles {  get; set; }
    }
}