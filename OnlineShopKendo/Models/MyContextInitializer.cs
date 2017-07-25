using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShopKendo.Models
{
    public class MyContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            db.Languages.Add(new Language {Name = "qq", Code = "qq"});
            db.SaveChanges();
        }
    }
}