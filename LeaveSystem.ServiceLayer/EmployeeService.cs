using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveSystem.DomainModels;
using LeaveSystem.ViewModels;
using LeaveSystem.Repositories;
using AutoMapper;
using AutoMapper.Configuration;
namespace LeaveSystem.ServiceLayer
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository er;
        public EmployeeService()
        {
            er = new EmployeeRepository();
        }

        public EmployeeViewModel GetEmail(int id)
        {
            Employee le = this.er.GetEmail(id);
            EmployeeViewModel evm = null;
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<Employee, EmployeeViewModel>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            evm = mapper.Map<Employee, EmployeeViewModel>(le);
            return evm;
        }

        public EmployeeViewModel GetEmployeeByID(int EmployeeID)
        {
            Employee e = er.GetEmployeeByID(EmployeeID).FirstOrDefault();
            EmployeeViewModel evm = null;
            if (e != null)
            {
                var config = new MapperConfiguration(t =>
                {
                    t.CreateMap<Employee, EmployeeViewModel>();
                    t.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                evm = mapper.Map<Employee, EmployeeViewModel>(e);

            }
            return evm;
        }

        public void InsertEmployee(RegisterEmployeeViewModel uvm)
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<RegisterEmployeeViewModel, Employee>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Employee e = mapper.Map<RegisterEmployeeViewModel, Employee>(uvm);
            e.Password = SHA256HashGenerator.GenerateHash(uvm.Password);
            er.InsertEmployee(e);
        }
        public void UpdateEmployeeDetails(EditEmployeeDetailsViewModel uvm)
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<EditEmployeeDetailsViewModel, Employee>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Employee e = mapper.Map<EditEmployeeDetailsViewModel, Employee>(uvm);
            er.UpdateEmployeeDetails(e);
        }
        public void UpdateEmployeePassword(EditEmployeePasswordViewModel uvm)
        {
           
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<EditEmployeePasswordViewModel, Employee>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Employee e = mapper.Map<EditEmployeePasswordViewModel, Employee>(uvm);
            e.Password = SHA256HashGenerator.GenerateHash(uvm.Password);
            er.UpdateEmployeePassword(e);
        }
        public void DeleteEmployee(int EmployeeID)
        {
            er.DeleteEmployee(EmployeeID);
        }
        public LoginViewModel GetEmployeesLogin(string Email, string Password)
        {
            Employee e = er.GetEmployeesLogin(Email, SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            LoginViewModel uvm = null;
            if (e != null)
            {
                var config = new MapperConfiguration(t =>
                {
                    t.CreateMap<Employee, LoginViewModel>();
                    t.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Employee, LoginViewModel>(e);
            }
            return uvm;

        }
        public LoginViewModel GetEmployeeByEmail(string Email)
        {
            Employee e = er.GetEmployeeByEmail(Email).FirstOrDefault();
            LoginViewModel uvm = null;
            if (e != null)
            {
                var config = new MapperConfiguration(t =>
                {
                    t.CreateMap<Employee, LoginViewModel>();
                    t.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Employee, LoginViewModel>(e);
            }
            return uvm;
        }
        public  List<EmployeeViewModel> GetEmployees()
        {
            List<Employee> e = er.GetEmployees();
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<Employee, EmployeeViewModel>();
                t.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<EmployeeViewModel> evm = mapper.Map<List<Employee>, List<EmployeeViewModel>>(e);
            return evm;
        }
    }
}
