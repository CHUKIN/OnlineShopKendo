using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopKendo.Models
{
    public class OrderItem
    {
        [Key,Column(Order =0)]
        public int OrderId { get; set; }

        [Key, Column(Order = 1)]
        public int ItemId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }

        public int Count { get; set; }

    }
}