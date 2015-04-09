using Litmus.Domain.Entity;
using Litmus.Domain.Facade;
using System.Net.Http;
using System.Web.Http;

namespace Litmus.Web.Controllers{
    [RoutePrefix("api/project")]
    public class ProjectController : BasicApiController
    {
        private readonly IDomainFacade _facade;

        public ProjectController(IDomainFacade facade) {
            _facade = facade;
        }

        [HttpGet, Route("{id}")]
        public Project Get([FromUri]int id) {
            var item = _facade.GetProjectById(id);
            return item;
        }

        [HttpPut, Route]
        public HttpResponseMessage Put(Project model) {
            if(ModelState.IsValid) {
                var item = _facade.AddProject(model);
                return Accepted(item);
            }
            return Bad(ModelState);
        }

        [HttpPost, Route]
        public HttpResponseMessage Post(Project model) {
            if(ModelState.IsValid) {
                var item = _facade.EditProject(model);
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