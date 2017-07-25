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
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new MyContextInitializer());
        }
        public ApplicationContext() : base("DefaultConnection") { }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<Description> Descriptions { get; set; }

        public virtual DbSet<MenuLanguage> MenuLanguages { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }


        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }




        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}