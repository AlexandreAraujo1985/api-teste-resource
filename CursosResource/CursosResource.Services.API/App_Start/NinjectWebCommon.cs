[assembly: WebActivator.PreApplicationStartMethod(typeof(CursosResource.Services.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(CursosResource.Services.API.App_Start.NinjectWebCommon), "Stop")]

namespace CursosResource.Services.API.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using CursosResource.Application.Interfaces;
    using CursosResource.Application.Services;
    using CursosResource.Domain.Interfaces.Repositories;
    using CursosResource.Domain.Interfaces.Services;
    using CursosResource.Domain.Services;
    using CursosResource.Infra.Data.Repositories;
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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            //Suport WebAPI Injection
            GlobalConfiguration.Configuration.DependencyResolver = new WebApiContrib.IoC.Ninject.NinjectResolver(kernel);

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Base - Generic
            kernel.Bind(typeof(IApplicationService<>)).To(typeof(ApplicationService<>));
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));

            //Curso
            kernel.Bind<ICursoApplication>().To<CursoApplicationService>();
            kernel.Bind<ICursoService>().To<CursoService>();
            kernel.Bind<ICursoRepository>().To<CursoRepository>();

            //Professor
            kernel.Bind<IProfessorApplication>().To<ProfessorApplicationService>();
            kernel.Bind<IProfessorService>().To<ProfessorService>();
            kernel.Bind<IProfessorRepository>().To<ProfessorRepository>();

            //Aluno
            kernel.Bind<IAlunoApplication>().To<AlunoApplicationService>();
            kernel.Bind<IAlunoService>().To<AlunoService>();
            kernel.Bind<IAlunoRepository>().To<AlunoRepository>();

            //Matricula
            kernel.Bind<IMatriculaApplication>().To<MatriculaApplicationService>();
            kernel.Bind<IMatriculaService>().To<MatriculaService>();
            kernel.Bind<IMatriculaRepository>().To<MatriculaRepository>();
        }
    }
}
