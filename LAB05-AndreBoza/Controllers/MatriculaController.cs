using LAB05_AndreBoza.DTOs;
using LAB05_AndreBoza.Models;
using LAB05_AndreBoza.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_AndreBoza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatriculaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var matriculas = await _unitOfWork.Repository<Matricula>().GetAllAsync();
            return Ok(matriculas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var matricula = await _unitOfWork.Repository<Matricula>().GetByIdAsync(id);
            if (matricula == null) return NotFound();
            return Ok(matricula);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MatriculaDto dto)
        {
            if (dto == null) return BadRequest("Body vacío.");
            if (!dto.IdEstudiante.HasValue || !dto.IdCurso.HasValue)
                return BadRequest("IdEstudiante e IdCurso son requeridos.");

            var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(dto.IdEstudiante.Value);
            if (estudiante == null) return BadRequest("Estudiante no existe.");

            var curso = await _unitOfWork.Repository<Curso>().GetByIdAsync(dto.IdCurso.Value);
            if (curso == null) return BadRequest("Curso no existe.");

            var matricula = new Matricula
            {
                IdEstudiante = dto.IdEstudiante,
                IdCurso = dto.IdCurso,
                Semestre = dto.Semestre
            };

            await _unitOfWork.Repository<Matricula>().InsertWithoutSaveAsync(matricula);
            await _unitOfWork.Complete();

            return CreatedAtAction(nameof(GetById), new { id = matricula.IdMatricula }, matricula);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MatriculaDto dto)
        {
            if (dto == null) return BadRequest("Body vacío.");

            var matricula = await _unitOfWork.Repository<Matricula>().GetByIdAsync(id);
            if (matricula == null) return NotFound();

            if (dto.IdEstudiante.HasValue)
            {
                var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(dto.IdEstudiante.Value);
                if (estudiante == null) return BadRequest("Estudiante (nuevo) no existe.");
                matricula.IdEstudiante = dto.IdEstudiante;
            }

            if (dto.IdCurso.HasValue)
            {
                var curso = await _unitOfWork.Repository<Curso>().GetByIdAsync(dto.IdCurso.Value);
                if (curso == null) return BadRequest("Curso (nuevo) no existe.");
                matricula.IdCurso = dto.IdCurso;
            }

            matricula.Semestre = dto.Semestre;

            _unitOfWork.Repository<Matricula>().Update(matricula);
            await _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var matricula = await _unitOfWork.Repository<Matricula>().GetByIdAsync(id);
            if (matricula == null) return NotFound();

            _unitOfWork.Repository<Matricula>().Remove(matricula);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
