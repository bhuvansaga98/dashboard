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
        private readonly IUserRepository _userRepository;
        public DomainFacade(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }
        public Project AddProject(Project project)
        {
            _projectRepository.Create(project);
            return project;
        }

        public User AddUser(User user) {
            _userRepository.Create(user);
            return user;
        }

        public int DeleteProject(int id) {
            return _projectRepository.Delete(id);
        }

        public Project EditProject(Project model) {
            _projectRepository.Update(model);
            return model;
        }

        public Project GetProjectById(int id) {
            return _projectRepository.ById(id);
        }
    }
}
