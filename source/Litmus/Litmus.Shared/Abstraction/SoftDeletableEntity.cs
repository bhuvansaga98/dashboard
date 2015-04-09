using System;

namespace Litmus.Shared.Abstraction
{
    public class SoftDeletableEntity : Entity, ISoftDelete
    {
        public DateTime? Deleted { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
    }
}