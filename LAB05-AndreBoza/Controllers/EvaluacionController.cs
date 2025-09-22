using LAB05_AndreBoza.DTOs;
using LAB05_AndreBoza.Models;
using LAB05_AndreBoza.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_AndreBoza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EvaluacionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var evaluaciones = await _unitOfWork.Repository<Evaluacione>().GetAllAsync();
            return Ok(evaluaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evaluacion = await _unitOfWork.Repository<Evaluacione>().GetByIdAsync(id);
            if (evaluacion == null) return NotFound();
            return Ok(evaluacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EvaluacionDto dto)
        {
            var evaluacion = new Evaluacione
            {
                IdEstudiante = dto.IdEstudiante,
                IdCurso = dto.IdCurso,
                Calificacion = dto.Calificacion,
                Fecha = dto.Fecha
            };

            await _unitOfWork.Repository<Evaluacione>().InsertWithoutSaveAsync(evaluacion);
            await _unitOfWork.Complete();

            return CreatedAtAction(nameof(GetById), new { id = evaluacion.IdEvaluacion }, evaluacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EvaluacionDto dto)
        {
            var evaluacion = await _unitOfWork.Repository<Evaluacione>().GetByIdAsync(id);
            if (evaluacion == null) return NotFound();

            evaluacion.IdEstudiante = dto.IdEstudiante;
            evaluacion.IdCurso = dto.IdCurso;
            evaluacion.Calificacion = dto.Calificacion;
            evaluacion.Fecha = dto.Fecha;

            _unitOfWork.Repository<Evaluacione>().Update(evaluacion);
            await _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evaluacion = await _unitOfWork.Repository<Evaluacione>().GetByIdAsync(id);
            if (evaluacion == null) return NotFound();

            _unitOfWork.Repository<Evaluacione>().Remove(evaluacion);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
