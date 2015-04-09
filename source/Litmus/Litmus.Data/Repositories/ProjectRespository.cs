using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Litmus.Data.Abstraction;
using Litmus.Domain.Entity;
using Litmus.Domain.Repositories;

namespace Litmus.Data.Repositories
{
    public class ProjectRespository : EfRepository<Project>,IProjectRepository
    {
        public ProjectRespository(IDataContext context) : base(context){}
    }
}
