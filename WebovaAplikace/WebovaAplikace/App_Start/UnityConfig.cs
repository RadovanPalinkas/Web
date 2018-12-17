using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebovaAplikace.Models;
using WebovaAplikace.Repository;
using WebovaAplikace.Repository.IRepositories;
using WebovaAplikace.Repository.Repositories;

namespace WebovaAplikace
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<ICustomerModel, CustomerModel>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}