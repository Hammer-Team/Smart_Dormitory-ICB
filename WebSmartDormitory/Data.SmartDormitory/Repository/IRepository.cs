using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SmartDormitory.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        Task AddAsync(T entity);

        void Update(T entity);

        void Save();

        Task SaveAsync();

    }

}
