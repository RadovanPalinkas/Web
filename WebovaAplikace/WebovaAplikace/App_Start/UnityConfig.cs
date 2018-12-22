using System.Web.Mvc;
using Unity;
using WebovaAplikace.Models;
using WebovaAplikace.UnitsOfWork.Interfaces;
using WebovaAplikace.UnitsOfWork.Implementations;
using WebovaAplikace.Repositories.Interfaces;
using WebovaAplikace.Repositories.Implementations;
using WebovaAplikace.Common.DataFirst;
using System.Web.Http;
using Unity.Mvc5;

namespace WebovaAplikace
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();              
            container.RegisterType<DatabazeWebContext, DatabazeWebContext>();            
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}