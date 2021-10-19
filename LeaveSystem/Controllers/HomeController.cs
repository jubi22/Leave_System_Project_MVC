using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveSystem.ServiceLayer;
using LeaveSystem.ViewModels;
using LeaveSystem.DomainModels;
namespace LeaveSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        readonly IEmployeeService es;
        public HomeController(IEmployeeService es)
        {
            this.es = es;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}