using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopKendo.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int Permission { get; set; }

        public virtual ICollection<MenuLanguage> MenuLanguages { get; set; }

    }
}