using LAB05_AndreBoza.Datos;
using LAB05_AndreBoza.Entidades;
using System.Threading.Tasks;
using LAB05_AndreBoza.Models;

namespace LAB05_AndreBoza.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Categoria> Categorias { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categorias = new GenericRepository<Categoria>(_context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}