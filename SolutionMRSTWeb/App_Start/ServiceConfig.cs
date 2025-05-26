using System.Web.Mvc;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.Core;

namespace SolutionMRSTWeb
{
    public static class ServiceConfig
    {
        public static void RegisterServices()
        {
            // Register services
            DependencyResolver.SetResolver(new NinjectDependencyResolver());
        }
    }
} 