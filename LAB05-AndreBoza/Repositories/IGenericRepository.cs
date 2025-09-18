using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LAB05_AndreBoza.Repositorios
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task InsertAsync(T entity);
        Task InsertWithoutSaveAsync(T entity);
        Task UpdateAsync(T entity);
        void Update(T entity);
        Task RemoveAsync(T entity);
        void Remove(T entity);
    }
}