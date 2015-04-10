using Litmus.Domain.Entity;
using Litmus.Domain.Facade;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;

namespace Litmus.Web.Controllers{
    [RoutePrefix("api/project")]
    public class ProjectController : BasicApiController
    {
        private readonly IDomainFacade _facade;

        public ProjectController(IDomainFacade facade) {
            _facade = facade;
        }

        [HttpGet, Route("all"), EnableQuery]
        public IQueryable<Project> GetAll() {
            return _facade.AllProject();
        }

        [HttpGet, Route("{id}")]
        public Project Get([FromUri]int id) {
            var item = _facade.GetProjectById(id);
            return item;
        }

        [HttpPut, Route]
        public HttpResponseMessage Put(Project model) {
            if(ModelState.IsValid) {
                var item = _facade.EditProject(model);
                return Accepted(item);
            }
            return Bad(ModelState);
        }

        [HttpPost, Route]
        public HttpResponseMessage Post(Project model) {
            if(ModelState.IsValid) {
                var UserId = _facade.AllUser().FirstOrDefault(x => x.Name == User.Identity.Name).Id;
                model.UserId = UserId; 
                var item = _facade.AddProject(model);
                return Accepted(item);
            }
            return Bad(ModelState);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage Delete([FromUri]int id) {
            if(ModelState.IsValid) {
                var item = _facade.DeleteProject(id);
                return Accepted(item);
            }
            return Bad(ModelState);
        }
    }
}