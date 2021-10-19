using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using LeaveSystem.ServiceLayer;
using System.Web.Mvc;
namespace LeaveSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<ILeaveServieLayer, LeaveServieLayer>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}