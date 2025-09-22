using LAB05_AndreBoza.DTOs;
using LAB05_AndreBoza.Models;
using LAB05_AndreBoza.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_AndreBoza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CursoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cursos = await _unitOfWork.Repository<Curso>().GetAllAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var curso = await _unitOfWork.Repository<Curso>().GetByIdAsync(id);
            if (curso == null) return NotFound();
            return Ok(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CursoDto dto)
        {
            var curso = new Curso
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Creditos = dto.Creditos
            };

            await _unitOfWork.Repository<Curso>().InsertWithoutSaveAsync(curso);
            await _unitOfWork.Complete();

            return CreatedAtAction(nameof(GetById), new { id = curso.IdCurso }, curso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CursoDto dto)
        {
            var curso = await _unitOfWork.Repository<Curso>().GetByIdAsync(id);
            if (curso == null) return NotFound();

            curso.Nombre = dto.Nombre;
            curso.Descripcion = dto.Descripcion;
            curso.Creditos = dto.Creditos;

            _unitOfWork.Repository<Curso>().Update(curso);
            await _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var curso = await _unitOfWork.Repository<Curso>().GetByIdAsync(id);
            if (curso == null) return NotFound();

            _unitOfWork.Repository<Curso>().Remove(curso);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
