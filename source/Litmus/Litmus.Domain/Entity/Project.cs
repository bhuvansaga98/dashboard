using System;
using Litmus.Shared.Abstraction;
using System.Collections.Generic;

namespace Litmus.Domain.Entity
{
    public class Project : SoftDeletableEntity
    {
        public User Users { get; set; }
        public int UserId { get; set; }
    }
}
