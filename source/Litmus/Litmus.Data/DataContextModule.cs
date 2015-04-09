using Autofac;
using Litmus.Data.Abstraction;
using System.Data.Entity;

namespace Litmus.Data {
    public class DataContextModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<DataContext>().As<IDataContext>();
            Database.SetInitializer(new NullDatabaseInitializer<DataContext>());
        }
    }
}