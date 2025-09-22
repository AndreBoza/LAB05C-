using LAB05_AndreBoza.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_AndreBoza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAsistencias()
        {
            return Ok("Lista de asistencias");
        }

        [HttpGet("{id}")]
        public IActionResult GetAsistenciaById(int id)
        {
            return Ok($"Asistencia con ID {id}");
        }

        [HttpPost]
        public IActionResult CrearAsistencia([FromBody] AsistenciaDto asistencia)
        {
            return Ok($"Asistencia registrada para estudiante {asistencia.IdEstudiante}");
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarAsistencia(int id, [FromBody] AsistenciaDto asistencia)
        {
            return Ok($"Asistencia con ID {id} actualizada");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarAsistencia(int id)
        {
            return Ok($"Asistencia con ID {id} eliminada");
        }
    }
}