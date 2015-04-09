using Litmus.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litmus.Domain.Facade
{
    public interface IDomainFacade
    {
        Project AddProject(Project project);
    }
}
