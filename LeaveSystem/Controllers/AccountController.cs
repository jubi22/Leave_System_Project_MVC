using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveSystem.DomainModels;
using LeaveSystem.ViewModels;
using LeaveSystem.ServiceLayer;
using LeaveSystem.CustomFilters;
namespace LeaveSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        readonly IEmployeeService es;
        readonly IRoleServiceLayer rs;
        public AccountController(EmployeeService es, RoleServiceLayer rs)
        {
            this.es = es;
            this.rs = rs;
        }
       
        public ActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel();
            return View(lvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                LoginViewModel lvm = this.es.GetEmployeesLogin(login.EmployeeEmail, login.Password);
                if (lvm != null)
                {
                    Session["CurrentPermission"] = lvm.IsSpecialPermission;
                    Session["CurrentRoleID"] = lvm.RoleID;
                    Session["CurrentEmpID"] = lvm.EmployeeID;

                    Session["CurrentEmail"] = lvm.EmployeeEmail;

                    Session["CurrentName"] = lvm.EmployeeName;

                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ModelState.AddModelError("x", "Invalid Credentials");
            }
            return View(login);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [UserAuthorization]
        [RoleAuthorization]
        public ActionResult Create()
        {
            List<RoleViewModel> roles = this.rs.GetRoles();
            ViewBag.roles = roles;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorization]
        [RoleAuthorization]
        public ActionResult Create(RegisterEmployeeViewModel register)
        {
            if (Request.Files.Count >= 1 && register.Image!=null)
            {
                var file = Request.Files[0];
                var imgbytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgbytes, 0, file.ContentLength);
                var base64string = Convert.ToBase64String(imgbytes, 0, imgbytes.Length);
                register.Image = base64string;
            }
            if (ModelState.IsValid)
            {

                
                this.es.InsertEmployee(register);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }
        [UserAuthorization]
        public ActionResult UpdateProfile()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorization]
        public ActionResult UpdateProfile(EditEmployeeDetailsViewModel edit)
        {
            if (ModelState.IsValid)
            {
                edit.EmployeeID = Convert.ToInt32(Session["CurrentEmpID"]);
                this.es.UpdateEmployeeDetails(edit);
                Session["CurrentName"] = edit.EmployeeName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }
        [UserAuthorization]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorization]
        public ActionResult ChangePassword(EditEmployeePasswordViewModel pwd)
        {
            if (ModelState.IsValid)
            {
                pwd.EmployeeID = Convert.ToInt32(Session["CurrentEmpID"]);
                this.es.UpdateEmployeePassword(pwd);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }
        [UserAuthorization]
        [HttpPost]
       
        public ActionResult Search(string str, int roleid)
        {
            if (roleid!=0)
            {
                List<EmployeeViewModel> employees = this.es.GetEmployees().Where(
                    t => t.RoleID == roleid &&
                    t.EmployeeName.ToLower().Contains(str.ToLower())).ToList();
                ViewBag.str = str;
                return View(employees);
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                
                return RedirectToAction("Index", "Home");
            }
        }
        [UserAuthorization]
        public ActionResult Delete(int employeeid)
        {
            this.es.DeleteEmployee(employeeid);
            return RedirectToAction("Index", "Home");
        }
        [UserAuthorization]
        public ActionResult Showemp(int id)
        {
           
            EmployeeViewModel e = this.es.GetEmployeeByID(id);
            return View(e);
        }
        [UserAuthorization]
        public ActionResult EditEmployee(int id)
        {
            EmployeeViewModel e = this.es.GetEmployeeByID(id);
            return View(e);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorization]
        public ActionResult EditEmployee(EditEmployeeDetailsViewModel edit)
        {
            if(ModelState.IsValid)
            {
                this.es.UpdateEmployeeDetails(edit);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }

        }
       
    }
}