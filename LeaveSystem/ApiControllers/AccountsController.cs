using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LeaveSystem.ServiceLayer;
using LeaveSystem.ViewModels;
namespace LeaveSystem.ApiControllers
{
    public class AccountsController : ApiController
    {
       
            IEmployeeService es;
            public AccountsController(IEmployeeService es)
            {
                this.es = es;
            }
            public string Get(string Email)
            {
                if (es.GetEmployeeByEmail(Email) != null)
                {
                    return "Found";
                }
                else
                {
                    return "Not Found";
                }
            }
    }
}
