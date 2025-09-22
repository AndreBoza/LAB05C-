using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LAB05_AndreBoza.Models
{
    public partial class Asistencia
    {
        [Key] // <-- Aquí indicas que es la PK
        public int IdAsistencia { get; set; }

        public int? IdEstudiante { get; set; }

        public int? IdCurso { get; set; }

        public DateOnly? Fecha { get; set; }

        public string? Estado { get; set; }

        public virtual Curso? IdCursoNavigation { get; set; }

        public virtual Estudiante? IdEstudianteNavigation { get; set; }
    }
}