using LAB05_AndreBoza.Entidades;
using LAB05_AndreBoza.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB05_AndreBoza.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        // Agrega aquí los DbSet de tus demás entidades
    }
}