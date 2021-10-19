using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace LeaveSystem.CustomFilters
{
    public class UserAuthorization: FilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            if (context.RequestContext.HttpContext.Session["CurrentEmpID"] == null)
            {
                context.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Home", action = "Index" }));
            }
        }
    }
    public class RoleAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            if (Convert.ToInt32(context.RequestContext.HttpContext.Session["CurrentRoleID"]) !=2)
            {
                context.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Home", action = "Index" }));
            }
        }
    }

    public class HRAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            if (Convert.ToInt32(context.RequestContext.HttpContext.Session["CurrentRoleID"]) == 2
                && Convert.ToInt32(context.RequestContext.HttpContext.Session["CurrentPermission"])==0)
            {
                context.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Home", action = "Index" }));
            }
            else if(Convert.ToInt32(context.RequestContext.HttpContext.Session["CurrentRoleID"]) == 3)
            {
                context.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                 new { controller = "Home", action = "Index" }));
            }


            
        }
    }
    public class EmpAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            if (Convert.ToInt32(context.RequestContext.HttpContext.Session["CurrentRoleID"]) != 2
                || Convert.ToInt32(context.RequestContext.HttpContext.Session["CurrentPermission"]) == 0)
            {
                context.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Home", action = "Index" }));
            }
        }
    }
}