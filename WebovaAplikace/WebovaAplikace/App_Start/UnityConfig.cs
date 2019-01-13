using System.Web.Mvc;
using Unity;
using WebovaAplikace.Models;
using WebovaAplikace.UnitsOfWork.Interfaces;
using WebovaAplikace.UnitsOfWork.Implementations;
using WebovaAplikace.Repositories.Interfaces;
using WebovaAplikace.Repositories.Implementations;
using System.Web.Http;
using Unity.Mvc5;
using WebovaAplikace.Common.DbContextDataFirst.Interfaces;
using WebovaAplikace.Common.DbContextDataFirst.Implementations;
using WebovaAplikace.Common.Authentication.Implementations;

//1) Nastavení container aby injektoval i v Api Controlerech
namespace WebovaAplikace
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IDbContext, DatabazeWebContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            ////**1**
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

        }

    }
}