using System.Threading.Tasks;

namespace LAB05_AndreBoza.Repositorios
{
    public interface IUnitOfWork
    {
        // Devuelve un repositorio genérico para cualquier entidad
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        // Guarda los cambios en la base de datos
        Task<int> Complete();
    }
}