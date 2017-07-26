using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using OnlineShopKendo.Filters;
using OnlineShopKendo.Models;

namespace OnlineShopKendo.Controllers
{

   
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
        public ActionResult Index(string textRu, string textEn, IEnumerable<HttpPostedFileBase> files, int cost)
        {
            var image = files.First();
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

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Item_Read([DataSourceRequest] DataSourceRequest request)
        {
            ICollection<ItemView> items = new List<ItemView>();
            foreach (var item in db.Items.ToList())
            {
                items.Add(new ItemView {Id = item.Id, Cost = item.Cost,TextRu = item.Descriptions.First(i=>i.Language.Code=="ru").Text, TextEn = item.Descriptions.First(i => i.Language.Code == "en").Text});
            }
            return Json(items.ToDataSourceResult(request));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Item_Update([DataSourceRequest] DataSourceRequest request, ItemView itemView)
        {
            if (itemView != null && ModelState.IsValid)
            {
                var result = db.Items.ToList().First(i => i.Id == itemView.Id);
                result.Cost = itemView.Cost;
                result.Descriptions.ToList().First(i => i.Language.Code == "ru").Text = itemView.TextRu;
                result.Descriptions.ToList().First(i => i.Language.Code == "en").Text = itemView.TextEn;
                db.SaveChanges();
            }
            return Json(new[] { itemView }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Item_Destroy([DataSourceRequest] DataSourceRequest request, ItemView itemView)
        {
            if (itemView != null)
            {
                var item = db.Items.First(i => i.Id == itemView.Id);
                foreach (var description in item.Descriptions.ToList())
                {
                    db.Descriptions.Remove(description);
                }
                db.Items.Remove(item);
                db.SaveChanges();
            }
            return Json(new[] { itemView }.ToDataSourceResult(request, ModelState));
        }
    }
}