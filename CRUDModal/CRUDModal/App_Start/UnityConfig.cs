using System.Web.Mvc;
using CRUDModal.BusinessLogic.Service;
using CRUDModal.BusinessLogic.Service.Repository;
using CRUDModal.Common.Repository;
using CRUDModal.Common.Service;
using Unity;
using Unity.Mvc5;

namespace CRUDModal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // Service Tribe

            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IDataOvertimeService, DataOvertimeService>();
            
            // Repository Tribe
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IDataOvertimeRepository, DataOvertimeRepository>();
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}