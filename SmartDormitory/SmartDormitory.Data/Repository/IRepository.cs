using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartDormitory.Data.Models;

namespace SmartDormitory.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entity);
        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
        Task SaveAsync();
    }
}
