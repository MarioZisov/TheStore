[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TheStore.Site.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TheStore.Site.App_Start.NinjectWebCommon), "Stop")]

namespace TheStore.Site.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using TheStore.Core.Domain;
    using TheStore.Data;
    using TheStore.Services.CategoryServiceComponents;
    using TheStore.Services.Interfaces;
    using TheStore.Services.PictureServiceComponents;
    using TheStore.Site.ModelsFactories;
    using TheStore.Site.ModelsFactories.Interfaces;
    using NinjectDependencyResolver = Ninject.Web.WebApi.NinjectDependencyResolver;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<TheStoreContext>();
            kernel.Bind<IPictureService>().To<PictureService>();
            kernel.Bind<IRepository<Picture>>().To<Repository<Picture>>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IRepository<Category>>().To<Repository<Category>>();
            kernel.Bind<ICategoryModelFactory>().To<CategoryModelFactory>();
        }        
    }
}