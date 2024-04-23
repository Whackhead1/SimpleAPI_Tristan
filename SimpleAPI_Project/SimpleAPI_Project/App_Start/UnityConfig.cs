using SimpleAPI_Project.Data;
using SimpleAPI_Project.Data.Repository;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace SimpleAPI_Project
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IApplicantRepository, ApplicantRepo>(new HierarchicalLifetimeManager());
            container.RegisterFactory<DataContext>(c => new DataContext());

            //dependency injection resolution
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //the below lets Unity control the resolution of the Controllers. This avoids conflict
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
} 