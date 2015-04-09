using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Litmus.Shared.Abstraction;
using System.Data.Entity;

namespace Litmus.Data.Abstraction
{
     public interface IDataContext {
        int SaveChanges();
        Task<int> SaveChangesAsync();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void SetEntryState<TEntity>(TEntity entity, EntityState state) where TEntity : class;
    }

     public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected EfRepository(IDataContext context)
        {
            Context = context;
        }

        private IDataContext  Context { get; set; }
        internal delegate void EntityEvent(TEntity entity);

        public virtual IQueryable<TEntity> ById(IEnumerable<int> ids)
        {
            return All.Where(x => ids.Contains(x.Id));
        }

        public virtual IQueryable<TEntity> All
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        public virtual int Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            var rowsAfftected = Context.SaveChanges();
            return rowsAfftected;
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            Context.SetEntryState(entity, EntityState.Added);
            var result= await Context.SaveChangesAsync();
            return result;
        }

        public virtual TEntity ById(int id)
        {
            var entity = Context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            if(entity is ISoftDelete) if((entity as ISoftDelete).IsDeleted) return null;
            return entity;
        }

        public virtual async Task<TEntity> ByIdAsync(int id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if(entity is ISoftDelete) if((entity as ISoftDelete).IsDeleted) return null;
            return entity;
        }

        private void SoftDelete(ISoftDelete entity)
        {
            entity.IsDeleted = true;
            entity.Deleted = DateTime.UtcNow;
        }

        public virtual int Delete(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            if(entity is ISoftDelete)
            {
                SoftDelete(entity as ISoftDelete);
            }
            else
            {
                Context.Set<TEntity>().Remove(entity);
            }
            var rowsAffected = Context.SaveChanges();
            return rowsAffected;
        }

        public virtual int Delete(int id)
        {
            return Delete(ById(id));
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            return await DeleteAsync(await ByIdAsync(id));
        }


        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            if(entity is ISoftDelete)
            {
                SoftDelete(entity as ISoftDelete);
            }
            else
            {
                Context.Set<TEntity>().Remove(entity);
            }
            var result= await Context.SaveChangesAsync();
            return result;
        }

        public virtual int Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.SetEntryState(entity, EntityState.Modified);
            var rowsAffected = Context.SaveChanges();
            return rowsAffected;
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.SetEntryState(entity, EntityState.Modified);
            var result= await Context.SaveChangesAsync();
            return result;
        }

        protected void AttachDetachedCollection<T>(ICollection<T> entities) where T : class
        {
            foreach(T entity in entities)
            {
                Context.Set<T>().Attach(entity);
                Context.SetEntryState(entity, EntityState.Unchanged);
            }
        }

        public void Attach(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
        }
        internal void Attach(ICollection<TEntity> entities)
        {
            throw new NotImplementedException();
            // Context.Set<TEntity>().Attach(entities);
        }

        public virtual int Create(ICollection<TEntity> entities)
        {
            Attach(entities);
            return Context.SaveChanges();
        }

        public virtual int Delete(ICollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> CreateAsync(ICollection<TEntity> entities)
        {
            Attach(entities);
            return await Context.SaveChangesAsync();
        }

        public virtual Task<int> DeleteAsync(ICollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

    }
}
