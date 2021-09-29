using BirthdayService;
using BirthdayServiceImplementation;
using RealmService;
using RealmServiceImplementation;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BirthdayWishes
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployees, Employees>();
            container.RegisterType<IBirthdayWishesService, BirthdayWishesService>();
            container.RegisterType<IHttpClientWrapper, HttpClientWrapper>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}