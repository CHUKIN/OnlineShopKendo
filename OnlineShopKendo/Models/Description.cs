using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopKendo.Models
{
    public class Description
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public virtual Language Language { get; set; }

        public virtual Item Item { get; set; }

    }
}