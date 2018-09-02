using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Heppers
{
    public class AtributeDangNhap : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["loggedUser"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { area = string.Empty, controller = "Account", action = "Login", redirectUrl = HttpContext.Current.Request.Url.PathAndQuery }));
            }

            if (filterContext.HttpContext.Session["loggedUser"] != null)
            {
                var user = (Session)filterContext.HttpContext.Session["loggedUser"];
                var routeData = filterContext.HttpContext.Request.RequestContext.RouteData;
                string currentAction = routeData.GetRequiredString("action");
                string currentController = routeData.GetRequiredString("controller");
                string currentArea = routeData.Values["area"] as string;
            }

        }
    }
}
