using GestorDeEventosSolucion.Data;
using GestorDeEventosSolucion.Molder;
using GestorDeEventosSolucion.Molder.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorDeEventosSolucion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsablesController : ControllerBase
    {
        private readonly DataContext _context;

        public ResponsablesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsableDto>>> GetResponsables()
        {
            var responsables = await _context.Responsables
                .Select(r => new ResponsableDto
                {
                    Id = r.Id,
                    FullName = r.FullName,
                    Role = r.Role,
                    PhoneNumber = r.PhoneNumber,
                    Email = r.Email
                }).ToListAsync();

            return Ok(responsables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponsableDto>> GetResponsable(int id)
        {
            var responsable = await _context.Responsables.FindAsync(id);

            if (responsable == null) return NotFound("Responsable no encontrado.");

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

            _context.Responsables.Add(responsable);
            await _context.SaveChangesAsync();

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
            var responsable = await _context.Responsables.FindAsync(id);

            if (responsable == null) return NotFound("Responsable no encontrado.");

            responsable.FullName = dto.FullName;
            responsable.Role = dto.Role;
            responsable.PhoneNumber = dto.PhoneNumber;
            responsable.Email = dto.Email;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsable(int id)
        {
            var responsable = await _context.Responsables.FindAsync(id);

            if (responsable == null) return NotFound("Responsable no encontrado.");

            _context.Responsables.Remove(responsable);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}