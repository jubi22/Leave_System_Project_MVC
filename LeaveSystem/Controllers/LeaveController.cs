using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveSystem.ServiceLayer;
using LeaveSystem.ViewModels;
using LeaveSystem.DomainModels;
using LeaveSystem.CustomFilters;
using System.Net.Mail;
using System.Net;
namespace LeaveSystem.Controllers
{
    public class LeaveController : Controller
    {
        // GET: Leave
        readonly ILeaveServieLayer ls;
        readonly IEmployeeService es;
        public LeaveController(LeaveServieLayer ls,EmployeeService es)
        {
            this.ls = ls;
            this.es = es;
        }
        [UserAuthorization]
        public ActionResult ApplyLeave()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorization]
        public ActionResult ApplyLeave(ApplyLeaveViewModel apply)
        {
            if (ModelState.IsValid)
            {
                Session["CurrentEmpID"] = apply.EmployeeID;
                Session["CurrentLeaveID"] = apply.LeaveID;
                this.ls.ApplyLeaves(apply);
                return RedirectToAction("ApplyLeave", "Leave");
            }
            else
            {
                ModelState.AddModelError("x", "invalid data");
                return View();
            }
        
        }
        [UserAuthorization]
        [HRAuthorization]
      
        public ActionResult Approve()
        {

            List<LeaveDetailsViewModel> l = this.ls.GetLeaves().ToList();
            return View(l);
        }
        public ActionResult Display()
        {
        
            return View(); 
        }
        [HttpPost]
        public ActionResult Display(EditLeaveViewModel evm)
        {
            this.ls.UpdateLeave(evm);
            var e= this.es.GetEmail(evm.EmployeeID);
            var e1 = this.es.GetEmployeeByID(evm.ApproverID);
            var sender = new MailAddress("trailprojectqb@gmail.com", "Project Manager");
            var reciever = new MailAddress(e.EmployeeEmail, e.EmployeeName);
            var pwd = "trialqb20";
            var sub = "Regarding Leave request for LeaveID: " + evm.LeaveID;
            var body = "Leave Start Date :" + evm.LeaveStartDate +
                "\n\nLeave End Date : " + evm.LeaveEndDate +
                "\n\nLeave Reason : " + evm.LeaveDescription +
                "\n\nLeave Status : " + evm.Status +               
                "\n\n" +evm.Status + " By : " + e1.EmployeeName;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sender.Address, pwd)

            };

            using (var mess = new MailMessage(sender, reciever)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }

            return RedirectToAction("Approve", "Leave");
      
        }
        [UserAuthorization]
        public ActionResult Show(int id)
        {
            
            List<LeaveDetailsViewModel> l = this.ls.GetLeaveByID(id);
            return View(l);
        }
        [UserAuthorization]
        [RoleAuthorization]
        public ActionResult ShowallLeaves()
        {
            List<LeaveDetailsViewModel> l = this.ls.GetLeaves();
            
            return View(l);
        }
    }
}