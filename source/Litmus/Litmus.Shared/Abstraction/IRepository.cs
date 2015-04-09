using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Litmus.Shared.Abstraction
{
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : IEntity { }

    public interface IRepository<TEntity,in TKey> where TEntity : IEntity
    {
        TEntity ById(TKey id);
        Task<TEntity> ByIdAsync(TKey id);
        IQueryable<TEntity> ById(IEnumerable<TKey> ids);
        int Create(TEntity entity); //returns Rows Affected
        int Update(TEntity entity); //returns Rows Affected
        int Delete(TEntity entity); //returns Rows Affected
        int Delete(TKey id); //returns Rows Affected
        void Attach(TEntity entity);
        Task<int> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity); //returns Rows Affected
        Task<int> DeleteAsync(TEntity entity); //returns Rows Affected
        Task<int> DeleteAsync(TKey id); //returns Rows Affected
        IQueryable<TEntity> All { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}