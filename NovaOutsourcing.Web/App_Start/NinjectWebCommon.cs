using NovaOutsourcing.Domain.Interfaces.Repositories;
using NovaOutsourcing.Domain.Interfaces.Services;
using NovaOutsourcing.Domain.Services;
using NovaOutsourcing.Util.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NovaOutsourcing.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NovaOutsourcing.Web.App_Start.NinjectWebCommon), "Stop")]

namespace NovaOutsourcing.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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

            kernel.Bind(typeof (IServiceBase<>)).To(typeof (ServiceBase<>));
            kernel.Bind<INewsletterService>().To<NewsletterService>();
            kernel.Bind<IVisitanteService>().To<VisitanteService>();

            kernel.Bind(typeof (IRepositoryBase<>)).To(typeof (RepositoryBase<>));
            kernel.Bind<INewsletterRepository>().To<NewsletterRepository>();
            kernel.Bind<IVisitanteRepository>().To<VisitanteRepository>();
        }
    }
}
