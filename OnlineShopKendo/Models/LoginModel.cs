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
        //[Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Resources.Resource))]
        //[DisplayName("login")]
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Resources.Resource))]
        [LocalizedDisplayName("RegUsername", NameResourceType = typeof(Resources.Resource))]
        public string Login { get; set; }
        [Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}