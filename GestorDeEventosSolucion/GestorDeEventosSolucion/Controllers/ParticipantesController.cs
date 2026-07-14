using GestorDeEventosSolucion.Data;
using GestorDeEventosSolucion.Molder;
using GestorDeEventosSolucion.Molder.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorDeEventosSolucion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly DataContext _context;

        public ParticipantesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipanteDto>>> GetParticipantes()
        {
            var participantes = await _context.Participantes
                .Select(p => new ParticipanteDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    IdentificationId = p.IdentificationId,
                    PhoneNumber = p.PhoneNumber,
                    Email = p.Email
                }).ToListAsync();

            return Ok(participantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipanteDto>> GetParticipante(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null) return NotFound("Participante no encontrado.");

            var participanteDto = new ParticipanteDto
            {
                Id = participante.Id,
                FullName = participante.FullName,
                IdentificationId = participante.IdentificationId,
                PhoneNumber = participante.PhoneNumber,
                Email = participante.Email
            };

            return Ok(participanteDto);
        }

        [HttpPost]
        public async Task<ActionResult<ParticipanteDto>> PostParticipante(CreateParticipanteDto dto)
        {
            var participante = new Participante
            {
                FullName = dto.FullName,
                IdentificationId = dto.IdentificationId,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };

            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();

            var participanteDto = new ParticipanteDto
            {
                Id = participante.Id,
                FullName = participante.FullName,
                IdentificationId = participante.IdentificationId,
                PhoneNumber = participante.PhoneNumber,
                Email = participante.Email
            };

            return CreatedAtAction(nameof(GetParticipante), new { id = participante.Id }, participanteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipante(int id, UpdateParticipanteDto dto)
        {
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null) return NotFound("Participante no encontrado.");

            participante.FullName = dto.FullName;
            participante.IdentificationId = dto.IdentificationId;
            participante.PhoneNumber = dto.PhoneNumber;
            participante.Email = dto.Email;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipante(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null) return NotFound("Participante no encontrado.");

            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}