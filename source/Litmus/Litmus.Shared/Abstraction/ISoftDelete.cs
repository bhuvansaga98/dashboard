using System;

namespace Litmus.Shared.Abstraction
{
    public interface ISoftDelete
    {
        DateTime? Deleted { get; set; }
        bool IsDeleted { get; set; }
        string DeletedBy { get; set; }
    }
}