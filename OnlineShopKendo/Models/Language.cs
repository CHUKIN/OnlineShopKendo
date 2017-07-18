using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopKendo.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }
    }
}