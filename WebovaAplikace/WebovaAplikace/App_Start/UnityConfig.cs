using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebovaAplikace.Models;
using WebovaAplikace.UnitsOfWork.Interfaces;
using WebovaAplikace.UnitsOfWork.Implementations;
using Infrastructure;
using WebovaAplikace.Repositories.Interfaces;
using WebovaAplikace.Repositories.Implementations;

namespace WebovaAplikace
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<EshopDataEntities, EshopDataEntities>();            
            container.RegisterType<IUnitOfWork, UnitOfWork>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}