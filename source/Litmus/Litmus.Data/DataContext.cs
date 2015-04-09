using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Litmus.Domain.Entity;

namespace Litmus.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
    }
}
