using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Litmus.Data;
using Litmus.Data.Facade;
using Litmus.Data.Repositories;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace Litmus.Web.App_Start {
    public class IocHelper {
        public static IContainer CreateContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<DataContextModule>();
            builder.RegisterModule<DataAccessLayerModule>();
            builder.RegisterModule<ServicesModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}