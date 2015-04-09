using Autofac;
using Litmus.Domain.Repositories;

namespace Litmus.Data.Repositories {
    public class DataAccessLayerModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<ProjectRespository>().As<IProjectRepository>();
        }
    }
}
