using Microsoft.AspNetCore.Mvc;
using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventosSolucion.Dtos.Responsable;

namespace GestorDeEventosSolucion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsablesController : ControllerBase
    {
        private readonly IResponsableRepository _responsableRepository;

        public ResponsablesController(IResponsableRepository responsableRepository)
        {
            _responsableRepository = responsableRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsableDto>>> GetResponsables()
        {
            var responsables = await _responsableRepository.GetAllAsync();

            var dtos = responsables.Select(r => new ResponsableDto
            {
                Id = r.Id,
                FullName = r.FullName,
                Role = r.Role,
                PhoneNumber = r.PhoneNumber,
                Email = r.Email
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponsableDto>> GetResponsable(int id)
        {
            var responsable = await _responsableRepository.GetByIdAsync(id);

            if (responsable == null)
            {
                return NotFound("Responsable no encontrado.");
            }

            var responsableDto = new ResponsableDto
            {
                Id = responsable.Id,
                FullName = responsable.FullName,
                Role = responsable.Role,
                PhoneNumber = responsable.PhoneNumber,
                Email = responsable.Email
            };

            return Ok(responsableDto);
        }

        [HttpPost]
        public async Task<ActionResult<ResponsableDto>> PostResponsable(CreateResponsableDto dto)
        {
            var responsable = new Responsable
            {
                FullName = dto.FullName,
                Role = dto.Role,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };

            await _responsableRepository.AddAsync(responsable);

            var responsableDto = new ResponsableDto
            {
                Id = responsable.Id,
                FullName = responsable.FullName,
                Role = responsable.Role,
                PhoneNumber = responsable.PhoneNumber,
                Email = responsable.Email
            };

            return CreatedAtAction(nameof(GetResponsable), new { id = responsable.Id }, responsableDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponsable(int id, UpdateResponsableDto dto)
        {
            var responsable = await _responsableRepository.GetByIdAsync(id);

            if (responsable == null)
            {
                return NotFound("Responsable no encontrado.");
            }

            responsable.FullName = dto.FullName;
            responsable.Role = dto.Role;
            responsable.PhoneNumber = dto.PhoneNumber;
            responsable.Email = dto.Email;

            await _responsableRepository.UpdateAsync(responsable);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsable(int id)
        {
            var responsable = await _responsableRepository.GetByIdAsync(id);

            if (responsable == null)
            {
                return NotFound("Responsable no encontrado.");
            }

            await _responsableRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}