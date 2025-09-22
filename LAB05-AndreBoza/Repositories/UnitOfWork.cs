
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LAB05_AndreBoza.Datos;

namespace LAB05_AndreBoza.Repositorios
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly Hashtable _repositories = new();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);
            if (_repositories.ContainsKey(type))
            {
                return (IGenericRepository<TEntity>)_repositories[type];
            }

            var repositoryInstance = new GenericRepository<TEntity>(_context);
            _repositories.Add(type, repositoryInstance);
            return repositoryInstance;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}