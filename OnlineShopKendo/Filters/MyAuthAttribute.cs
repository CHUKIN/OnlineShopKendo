using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace OnlineShopKendo.Filters
{
    public class MyAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public string Roles { get; set; }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated || !user.IsInRole(Roles))
            {
                filterContext.Result = new HttpStatusCodeResult(403);
            }
        }

        
    }
}