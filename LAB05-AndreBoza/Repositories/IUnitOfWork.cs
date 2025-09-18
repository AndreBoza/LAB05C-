using LAB05_AndreBoza.Entidades;
using System;
using System.Threading.Tasks;
using LAB05_AndreBoza.Models;

namespace LAB05_AndreBoza.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Categoria> Categorias { get; }
        // Puedes agregar aquí más repositorios, por ejemplo:
        // IGenericRepository<Curso> Cursos { get; }
        Task<int> SaveAsync();
    }
}