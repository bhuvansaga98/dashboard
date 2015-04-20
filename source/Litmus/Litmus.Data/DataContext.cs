using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Litmus.Domain.Entity;
using Litmus.Data.Abstraction;

namespace Litmus.Data
{
    public class DataContext : DbContext, IDataContext
    {

        public DataContext():base(nameOrConnectionString:"DefaultConnection"){}
        public DbSet<Project> Projects { get; set; }


        public void SetEntryState<TEntity>(TEntity entity, EntityState state) where TEntity:class {
            throw new NotImplementedException();
        }
    }
}
