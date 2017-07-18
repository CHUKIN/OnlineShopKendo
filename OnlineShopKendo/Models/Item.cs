using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopKendo.Models
{
    public class Item
    {

        //public Item()
        //{
        //    Orders = new HashSet<Order>();
        //    Descriptions=new HashSet<Description>();
        //}

        public int Id { get; set; }

        public int Cost { get; set; }

        public byte[] Image { get; set; }

        //public string Text { get; set; }

        public string ImageMimeType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }

    }
}