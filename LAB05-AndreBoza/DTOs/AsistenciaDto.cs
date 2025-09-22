namespace LAB05_AndreBoza.DTOs
{
    public class AsistenciaDto
    {
        public int IdAsistencia { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } // 'Presente', 'Ausente', 'Justificada'
    }
}