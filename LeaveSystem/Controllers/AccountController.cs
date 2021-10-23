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
       
        public ActionResult Login()         // Login Page
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
                    Session["CurrentImage"] = lvm.Image;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.mess = "Invalid Credentials";
                    return View(login);
                }

            }
            else
            {
              
              ModelState.AddModelError("x", "Invalid Credentials");
            }
            return View(login);
        }
        public ActionResult Logout()        // Logout Page
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [UserAuthorization]
        [RoleAuthorization]
        public ActionResult Create()        //To add a new employee by HR only
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
                ViewBag.mess = "Succesfuly added employee";
                return View();
            }
            else
            {
               
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }
        [UserAuthorization]
        public ActionResult UpdateProfile()         //Update Profile Information
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
                     ViewBag.mess = "Successfully Updated your Information";
                    edit.EmployeeID = Convert.ToInt32(Session["CurrentEmpID"]);
                    if (edit.EmployeeContactNo != null) 
                    {
                        this.es.UpdateEmployeeDetails(edit);
                    }
                    else
                    {

                        EmployeeViewModel evm = this.es.GetPhoneByID(edit.EmployeeID);
                        edit.EmployeeContactNo = evm.EmployeeContactno;
                        this.es.UpdateEmployeeDetails(edit);

                    }
                    Session["CurrentName"] = edit.EmployeeName;
                    return View();
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }
        [UserAuthorization]
        public ActionResult ChangePassword()        //Change password based on role
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
                ViewBag.mess = "Succesfully Changed your Password..";
                pwd.EmployeeID = Convert.ToInt32(Session["CurrentEmpID"]);
                this.es.UpdateEmployeePassword(pwd);
                return View();
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }
        [UserAuthorization]
        [HttpPost]
       
        public ActionResult Search(string str, int roleid)      //search employees bases on role category
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
        public ActionResult Delete(int employeeid)          //delete an employee by HR only 
        {
            this.es.DeleteEmployee(employeeid);
            return RedirectToAction("Index", "Home");
        }
        [UserAuthorization]
        public ActionResult Showemp(int id)             //View details of Employee
        {
           
            EmployeeViewModel e = this.es.GetEmployeeByID(id);
            return View(e);
        }
        [UserAuthorization]
        public ActionResult EditEmployee(int id)            //Update employee information by HR only
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
                if (edit.EmployeeName != null)
                {
                    if (edit.EmployeeContactNo != null)
                    {
                        this.es.UpdateEmployeeDetails(edit);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        EmployeeViewModel evm = this.es.GetPhoneByID(edit.EmployeeID);
                        edit.EmployeeContactNo = evm.EmployeeContactno;
                        this.es.UpdateEmployeeDetails(edit);
                       
                    }
                    return RedirectToAction("Index", "Home");

                }
                return View();
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }

        }
       
    }
}