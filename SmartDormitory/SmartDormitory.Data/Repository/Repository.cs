using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartDormitory.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDormitory.Data.Repository
{
    public class Repository<T> : IRepository<T> 
        where T : class
    {
        private readonly DormitoryContext context;

        public Repository(DormitoryContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            EntityEntry entry = context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                context.Set<T>().Add(entity);
            }
        }

        public async Task AddAsync(T entity)
        {
            EntityEntry entry = context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                await context.Set<T>().AddAsync(entity);
            }
        }

        public IQueryable<T> All()
        {
            return context.Set<T>();
        }

        void IRepository<T>.Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            EntityEntry entry = context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
