using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.Core;

namespace SolutionMRSTWeb
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Register all services
            _kernel.Bind<ISession>().To<SessionBL>();
            _kernel.Bind<IRecipeService>().To<RecipeService>();
            _kernel.Bind<ICategoryService>().To<CategoryService>();
        }
    }
} 