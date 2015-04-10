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
        IQueryable<User> AllUser();
        User AddUser(User user);

        IQueryable<Project> AllProject();
        Project AddProject(Project project);
        int DeleteProject(int id);
        Project EditProject(Project model);
        Project GetProjectById(int id);
    }
}
