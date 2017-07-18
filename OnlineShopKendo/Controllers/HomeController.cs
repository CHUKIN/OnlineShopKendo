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
            return View(db.Items.ToList());
        }

        public ActionResult Order(int[] idArray,int[] countArray)
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            Order order = new Order { Date = DateTime.Now,User = user};
            int cost = 0;
            db.Orders.Add(order);

            for (int i = 0; i < idArray.Length; i++)
            {
                var item = db.Items.Find(idArray[i]);
                int count = 0;
                var orderItem = new OrderItem { Item=item,Order=order, Count=countArray[i]};
                db.OrderItems.Add(orderItem);
                cost += item.Cost;
            }

            order.Cost = cost;
            db.SaveChanges();
            
            string result = "Успешно";
            return Content(idArray.Length.ToString());
        }

        public ActionResult PersonalArea()
        {
            return View(db.Orders.ToList());
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
