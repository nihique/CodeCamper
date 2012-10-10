using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using CodeCamper.Data.Contracts;

namespace CodeCamper.Data
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository(DbContext dbContext)
        {
            Context = dbContext;
            Set = Context.Set<T>();
        }

        protected DbSet<T> Set { get; private set; }

        protected DbContext Context { get; private set; }

        public T GetById(int id)
        {
            return Set.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return Set;
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Add(entity);
            }
            else
            {
                entry.State = EntityState.Added;
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                Set.Attach(entity);
                Set.Remove(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // already deleted
            Set.Remove(entity);
        }
    }
}