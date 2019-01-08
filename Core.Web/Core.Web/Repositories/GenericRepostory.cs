using Core.Web.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        CoreDbContext DbContext { get; }

        IEnumerable<T> GetAll();

        IEnumerable<T> Search(Func<T, bool> predicate);

        bool Exist();

        bool Exist(Func<T, bool> predicate);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void DetachAllEntities();
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public CoreDbContext DbContext { get; private set; }
        public GenericRepository(CoreDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public IEnumerable<T> Search(Func<T, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return DbContext.Set<T>().Where(predicate);
        }

        public bool Exist()
        {
            return DbContext.Set<T>().Any();
        }

        public bool Exist(Func<T, bool> predicate)
        {
            return DbContext.Set<T>().Any(predicate);
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbContext.Set<T>().UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(T));

            DbContext.Set<T>().RemoveRange(entities);
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            int result = await DbContext.SaveChangesAsync();
            DetachAllEntities();
            return result;
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = DbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}