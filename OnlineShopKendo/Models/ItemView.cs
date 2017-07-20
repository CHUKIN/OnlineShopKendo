using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OnlineShopKendo.Models
{
    public class ItemView
    {
        public int Id { get; set; }

        public int Cost { get; set; }

        //public byte[] Image { get; set; }

        //public string ImageMimeType { get; set; }

        public string TextRu { get; set; }
        public string TextEn { get; set; }

    }
}