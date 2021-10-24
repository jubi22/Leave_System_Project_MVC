using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace LeaveSystem.CustomFilters
{
    //Prevents displaying pages if no one is logged in site
    public class UserAuthorization: FilterAttribute,IAuthorizationFilter    
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            if (context.RequestContext.HttpContext.Session["CurrentEmpID"] == null )
            {
                context.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Home", action = "Index" }));
            }
        }
    }

    //Employees are not allowed to view other employees leave requests and add/update employee.
    //Only HR is allowed to do so.
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

    //HR with special permission and PM has the access to approve/reject leave requests.
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
    public class EmployeeAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            if (Convert.ToInt32(context.RequestContext.HttpContext.Session["CurrentRoleID"]) !=3  )
            {
                context.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Home", action = "Index" }));
            }
        }
    }
}