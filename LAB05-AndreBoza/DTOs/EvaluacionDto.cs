namespace LAB05_AndreBoza.DTOs
{
    public class EvaluacionDto
    {
        public int IdEvaluacion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public decimal Calificacion { get; set; }
        public DateOnly? Fecha { get; set; }
    }
}