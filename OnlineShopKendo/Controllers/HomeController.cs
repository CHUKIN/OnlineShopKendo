using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.IO;
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

    public class HomeController : Controller
    {
        ApplicationContext db = new ApplicationContext();
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie == null)
            {
                cookie = new HttpCookie("lang")
                {
                    HttpOnly = false,
                    Value = "ru",
                    Expires = DateTime.Now.AddYears(1)
                };
                Response.Cookies.Add(cookie);
            }
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
                var orderItem = new OrderItem { Item=item,Order=order, Count=countArray[i]};
                db.OrderItems.Add(orderItem);
                cost += item.Cost*countArray[i];
            }

            order.Cost = cost;
            db.SaveChanges();

            string language = Request.Cookies["lang"].Value;
            //string to = "id61899437-02ac7a125@vkmessenger.com";
            string to = db.Users.ToList().First(i => i.Id == User.Identity.GetUserId()).Email;
            string subject = Resources.Resource.OrderNumber+": "+order.OrderId;
            string message = Resources.Resource.OrderNumber + ": " + order.OrderId+"\n";
            foreach (var itemOrder in order.OrderItems.ToList())
            {
                var itemDescription = itemOrder.Item.Descriptions.First(i => i.Language.Code == language);
                message +=Resources.Resource.ItemId+": "+itemOrder.ItemId+" "+Resources.Resource.ItemName+": "+itemDescription.Text + " "+Resources.Resource.ItemCount+": "+itemOrder.Count+"\n";
            }
            message += Resources.Resource.TotalCost + ": " + order.Cost;
            Send(to,subject,message);

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


        public async Task Send(string to, string subject, string message)
        {
            WebRequest request = WebRequest.Create("http://smtpproxy.azurewebsites.net/api/send");
            request.Method = "POST";

            string data = $"to={to}&subject={subject}&message={message}";

            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            await request.GetResponseAsync();
        }




    }
}
