using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebovaAplikace.Models;
using WebovaAplikace.Repository;
using WebovaAplikace.Repository.IRepositories;
using WebovaAplikace.Repository.Repositories;
using WebovaAplikace.UnitsOfWork.Interfaces;
using WebovaAplikace.UnitsOfWork.Implementations;

namespace WebovaAplikace
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}