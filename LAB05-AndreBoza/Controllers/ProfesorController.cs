using LAB05_AndreBoza.DTOs;
using LAB05_AndreBoza.Models;
using LAB05_AndreBoza.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_AndreBoza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfesorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profesores = await _unitOfWork.Repository<Profesore>().GetAllAsync();
            return Ok(profesores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profesor = await _unitOfWork.Repository<Profesore>().GetByIdAsync(id);
            if (profesor == null) return NotFound();
            return Ok(profesor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProfesorDto dto)
        {
            var profesor = new Profesore
            {
                Nombre = dto.Nombre,
                Especialidad = dto.Especialidad,
                Correo = dto.Correo
            };

            await _unitOfWork.Repository<Profesore>().InsertWithoutSaveAsync(profesor);
            await _unitOfWork.Complete();

            return CreatedAtAction(nameof(GetById), new { id = profesor.IdProfesor }, profesor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProfesorDto dto)
        {
            var profesor = await _unitOfWork.Repository<Profesore>().GetByIdAsync(id);
            if (profesor == null) return NotFound();

            profesor.Nombre = dto.Nombre;
            profesor.Especialidad = dto.Especialidad;
            profesor.Correo = dto.Correo;

            _unitOfWork.Repository<Profesore>().Update(profesor);
            await _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profesor = await _unitOfWork.Repository<Profesore>().GetByIdAsync(id);
            if (profesor == null) return NotFound();

            _unitOfWork.Repository<Profesore>().Remove(profesor);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
