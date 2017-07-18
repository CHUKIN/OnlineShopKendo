using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopKendo.Models
{
    public class Item
    {
        public int Id { get; set; }

        public int Cost { get; set; }

        public byte[] Image { get; set; }

        public string ImageMimeType { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }

    }
}