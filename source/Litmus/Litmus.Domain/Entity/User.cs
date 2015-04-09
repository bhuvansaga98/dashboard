using Litmus.Shared.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litmus.Domain.Entity {
    public class User : SoftDeletableEntity {
        public IList<Project> Projects { get; set; }
    }
}