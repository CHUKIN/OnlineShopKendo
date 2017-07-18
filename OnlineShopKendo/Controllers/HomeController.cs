using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using MimeKit;
using OnlineShopKendo.Filters;
using OnlineShopKendo.Models;

namespace OnlineShopKendo.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        ApplicationContext db = new ApplicationContext();
        public ActionResult Index()
        {

            //foreach (var item in db.Items)
            //{
            //    foreach (var dec in item.Descriptions)
            //    {
            //        if (dec.Code == Request.Cookies["lang"].Value)
            //        {
            //            item.Text = dec.Text;
            //        }
            //    }
            //}
            //db.SaveChanges();
            //return View(db.Items.ToList());
            return View(db.Items.ToList());

        }

        public ActionResult Order(int[] idArray)
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            Order order = new Order { Date = DateTime.Now, UserId = user.Id };
            int cost = 0;
            db.Orders.Add(order);
            db.SaveChanges();

            foreach (var id in idArray)
            {
                var item = db.Items.Find(id);
                if (item != null)
                {
                   // db.Orderitems.Add(new OrderItems {OrderId = order.Id, ItemId = item.Id});
                    order.Items.Add(item);
                    cost += item.Cost;
                }
            }
            db.Orders.Find(order.Id).Cost = cost;
            db.SaveChanges();


            string result = "Успешно";
            return Content(result);
        }

        public ActionResult PersonalArea()
        {
            return View(db);
        }

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "ru", "en"};
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}
