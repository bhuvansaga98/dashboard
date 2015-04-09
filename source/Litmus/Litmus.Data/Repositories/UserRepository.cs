using Litmus.Data.Abstraction;
using Litmus.Domain.Entity;
using Litmus.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litmus.Data.Repositories {
    public class UserRespository:EfRepository<User>, IUserRepository {
        public UserRespository(IDataContext context) : base(context) { }
    }
}
