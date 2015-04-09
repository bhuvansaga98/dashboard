using Autofac;
using Litmus.Data.Abstraction;
using System.Data.Entity;

namespace Litmus.Data {
    public class DataContextModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<DataContext>().As<IDataContext>().As<DbContext>().As<DataContext>();
            Database.SetInitializer(new NullDatabaseInitializer<DataContext>());
        }
    }
}