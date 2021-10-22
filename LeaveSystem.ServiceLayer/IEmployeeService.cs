using LeaveSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveSystem.ServiceLayer
{
    public interface IEmployeeService
    {
        void InsertEmployee(RegisterEmployeeViewModel uvm);
        void UpdateEmployeeDetails(EditEmployeeDetailsViewModel uvm);

        void UpdateEmployeePassword(EditEmployeePasswordViewModel uvm);
        void DeleteEmployee(int EmployeeID);
        List<EmployeeViewModel> GetEmployees();
        LoginViewModel GetEmployeesLogin(string Email, string Password);
        LoginViewModel GetEmployeeByEmail(string Email);
        EmployeeViewModel GetEmployeeByID(int EmployeeID);

        EmployeeViewModel GetEmail(int id);
        EmployeeViewModel GetPhoneByID(int id);
    }
}
