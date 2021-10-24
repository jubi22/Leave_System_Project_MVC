using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveSystem.DomainModels;
namespace LeaveSystem.Repositories
{
    public  class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectDB dbcontext = new ConnectDB();
        
        public Employee GetEmail(int id)
        {
            Employee e = dbcontext.Employees.Where(t => t.EmployeeID == id).FirstOrDefault();
            return e;
        }

        public void InsertEmployee(Employee emp)
        {
            
            dbcontext.Employees.Add(emp);
            dbcontext.SaveChanges();
        }
        public List<Employee> GetEmployeeByID(int EmployeeID)
        {
            List<Employee> e = dbcontext.Employees.Where(t => t.EmployeeID == EmployeeID).ToList();
            return e;
        }


        public void UpdateEmployeeDetails(Employee emp)
        {
            Employee e = dbcontext.Employees.Where(t => t.EmployeeID == emp.EmployeeID).FirstOrDefault();
            if (e != null)
            {
                e.EmployeeName = emp.EmployeeName;
                e.EmployeeContactNo = emp.EmployeeContactNo;
               
                dbcontext.SaveChanges();
            }
        }
        public Employee GetPhoneByID(int id)
        {
            Employee e = dbcontext.Employees.Where(t => t.EmployeeID == id).FirstOrDefault();
            return e;
        }
        public void UpdateEmployeePassword(Employee emp)
        {
            Employee e = dbcontext.Employees.Where(t => t.EmployeeID == emp.EmployeeID).FirstOrDefault();
            if (e != null)
            {
                e.Password = emp.Password;
                dbcontext.SaveChanges();
            }
        }
        public void DeleteEmployee(int EmployeeID)
        {
            Employee e = dbcontext.Employees.Where(t => t.EmployeeID == EmployeeID).FirstOrDefault();
            dbcontext.Employees.Remove(e);
            dbcontext.SaveChanges();
        }
        public List<Employee> GetEmployeesLogin(string Email, string Password)
        {
            List<Employee> e = dbcontext.Employees.Where(t => t.EmployeeEmail == Email && t.Password == Password).ToList();
            return e;
        }
        public List<Employee> GetEmployeeByEmail(string Email)
        {
            List<Employee> e = dbcontext.Employees.Where(t => t.EmployeeEmail == Email).ToList();
            return e;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> e = dbcontext.Employees.ToList();
            return e;
        }
    }
}
