using LAB05_AndreBoza.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_AndreBoza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMaterias()
        {
            return Ok("Lista de materias");
        }

        [HttpGet("{id}")]
        public IActionResult GetMateriaById(int id)
        {
            return Ok($"Materia con ID {id}");
        }

        [HttpPost]
        public IActionResult CrearMateria([FromBody] Materia materia)
        {
            return Ok($"Materia {materia.Nombre} creada");
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarMateria(int id, [FromBody] Materia materia)
        {
            return Ok($"Materia con ID {id} actualizada");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarMateria(int id)
        {
            return Ok($"Materia con ID {id} eliminada");
        }
    }
}