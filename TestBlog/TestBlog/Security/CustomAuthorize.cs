using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestBlog.Models;

namespace TestBlog.Security
{
    public class CustomAuthorize: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["userdetails"] != null)
            {
                CustomPrincipal customPrincipal = new CustomPrincipal((UserDetails)HttpContext.Current.Session["userdetails"]);
                //if (!customPrincipal.IsInRole(((UserDetails)HttpContext.Current.Session["userdetails"]).role.ToString()))
                if (!customPrincipal.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Index" }));
                }
            }
            else
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Index" }));
        }
    }
}