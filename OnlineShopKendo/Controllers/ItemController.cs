using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopKendo.Filters;
using OnlineShopKendo.Models;

namespace OnlineShopKendo.Controllers
{
    [Culture]
   
    public class ItemController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        [HttpGet]

        [MyAuth (Roles="moderator")]
        public ActionResult Index()
        {
            return View();
        }

        [MyAuth(Roles = "moderator")]
        [HttpPost]
        public ActionResult Index(string textRu, string textEn, HttpPostedFileBase image, int cost)
        {
            Item item = new Item {  Image = new byte[image.ContentLength], ImageMimeType = image.ContentType, Cost = cost};      
            image.InputStream.Read(item.Image, 0, image.ContentLength);
            db.Items.Add(item);
            db.SaveChanges();

            Language languageEn = db.Languages.First(i => i.Code == "en");
            Language languageRu = db.Languages.First(i => i.Code == "ru");

            Description descriptionEn = new Description { Item=item, Language = languageEn, Text = textEn};
            Description descriptionRu = new Description { Item = item, Language = languageRu, Text = textRu};

            db.Descriptions.Add(descriptionRu);
            db.Descriptions.Add(descriptionEn);

            db.SaveChanges();

            ViewBag.Message = Resources.Resource.SuccessAddItem;
            return View();
        }

        public FileContentResult GetImage(int id)
        {
            Item item = db.Items.Find(id);
            return File(item.Image, item.ImageMimeType);
        }


    }
}