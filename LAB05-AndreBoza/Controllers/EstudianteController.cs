using LAB05_AndreBoza.DTOs;
using LAB05_AndreBoza.Models;
using LAB05_AndreBoza.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_AndreBoza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstudianteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estudiantes = await _unitOfWork.Repository<Estudiante>().GetAllAsync();
            return Ok(estudiantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
            if (estudiante == null) return NotFound();
            return Ok(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstudianteDto dto)
        {
            var estudiante = new Estudiante
            {
                Nombre = dto.Nombre,
                Edad = dto.Edad,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Correo = dto.Correo
            };

            await _unitOfWork.Repository<Estudiante>().InsertWithoutSaveAsync(estudiante);
            await _unitOfWork.Complete();

            return CreatedAtAction(nameof(GetById), new { id = estudiante.IdEstudiante }, estudiante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstudianteDto dto)
        {
            var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
            if (estudiante == null) return NotFound();

            estudiante.Nombre = dto.Nombre;
            estudiante.Edad = dto.Edad;
            estudiante.Direccion = dto.Direccion;
            estudiante.Telefono = dto.Telefono;
            estudiante.Correo = dto.Correo;

            _unitOfWork.Repository<Estudiante>().Update(estudiante);
            await _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
            if (estudiante == null) return NotFound();

            _unitOfWork.Repository<Estudiante>().Remove(estudiante);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
