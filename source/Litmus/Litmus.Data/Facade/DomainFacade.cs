using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Litmus.Domain.Facade;
using Litmus.Domain.Entity;
using Litmus.Domain.Repositories;

namespace Litmus.Data.Facade
{
    public class DomainFacade : IDomainFacade
    {
        private readonly IProjectRepository _projectRepository;
        public DomainFacade(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public Project AddProject(Project project)
        {
            _projectRepository.Create(project);
            return project;
        }
    }
}
