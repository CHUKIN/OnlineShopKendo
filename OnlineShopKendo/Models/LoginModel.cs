using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlineShopKendo.Filters;

namespace OnlineShopKendo.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Login", ResourceType = typeof(Resources.LoginModel))]
        public string Login { get; set; }



        [Required]
        [Display(Name = "Password", ResourceType = typeof(Resources.LoginModel))]
        public string Password { get; set; }
    }
}