using Autofac;
using Litmus.Domain.Facade;

namespace Litmus.Data.Facade {
    public class ServicesModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<DomainFacade>().As<IDomainFacade>();
        }
    }
}
