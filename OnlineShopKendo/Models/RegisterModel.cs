using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopKendo.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Login", ResourceType = typeof(Resources.RegisterModel))]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Email", ResourceType = typeof(Resources.RegisterModel))]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password", ResourceType = typeof(Resources.RegisterModel))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.RegisterModel))]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}