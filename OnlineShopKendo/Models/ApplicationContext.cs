using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineShopKendo.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("DefaultConnection") { }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<Description> Descriptions { get; set; }

        public virtual DbSet<MenuLanguage> MenuLanguages { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }


        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{ 
        //    modelBuilder.Entity<Item>()
        //        .HasMany(e => e.Orders)
        //        .WithMany(e => e.Items)
        //        .Map(m => m.ToTable("OrderItems").MapLeftKey("Item_Id").MapRightKey("Order_Id"));
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //}

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}