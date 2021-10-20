using LeaveSystem.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveSystem.Repositories
{
     public  interface IEmployeeRepository
    {
        void InsertEmployee(Employee emp);
        void UpdateEmployeeDetails(Employee emp);
        void UpdateEmployeePassword(Employee emp);
        void DeleteEmployee(int EmployeeID);
        List<Employee> GetEmployees();
        List<Employee> GetEmployeesLogin(string Email, string Password);
        List<Employee> GetEmployeeByEmail(string Email);
        List<Employee> GetEmployeeByID(int EmployeeID);

        Employee GetEmail(int id);
    }
}
