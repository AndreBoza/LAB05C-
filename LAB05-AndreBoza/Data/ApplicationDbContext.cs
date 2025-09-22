using LAB05_AndreBoza.Models; // Aquí sí están todas tus entidades
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
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Evaluacione> Evaluaciones { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Profesore> Profesores { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir claves primarias explícitas
            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria);
            modelBuilder.Entity<Curso>().HasKey(c => c.IdCurso);
            modelBuilder.Entity<Estudiante>().HasKey(e => e.IdEstudiante);
            modelBuilder.Entity<Evaluacione>().HasKey(e => e.IdEvaluacion);
            modelBuilder.Entity<Materia>().HasKey(m => m.IdMateria);
            modelBuilder.Entity<Matricula>().HasKey(m => m.IdMatricula);
            modelBuilder.Entity<Profesore>().HasKey(p => p.IdProfesor);
            modelBuilder.Entity<Asistencia>().HasKey(a => a.IdAsistencia);

            base.OnModelCreating(modelBuilder);
        }
    }
}