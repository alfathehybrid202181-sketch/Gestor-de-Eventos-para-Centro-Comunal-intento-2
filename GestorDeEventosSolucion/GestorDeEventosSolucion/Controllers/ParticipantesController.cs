using Microsoft.AspNetCore.Mvc;
using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventosSolucion.Dtos;

namespace GestorDeEventosSolucion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly IParticipanteRepository _participanteRepository;

        public ParticipantesController(IParticipanteRepository participanteRepository)
        {
            _participanteRepository = participanteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipanteDto>>> GetParticipantes()
        {
            var participantes = await _participanteRepository.GetAllAsync();

            var dtos = participantes.Select(p => new ParticipanteDto
            {
                Id = p.Id,
                FullName = p.FullName,
                IdentificationId = p.IdentificationId,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipanteDto>> GetParticipante(int id)
        {
            var participante = await _participanteRepository.GetByIdAsync(id);

            if (participante == null)
            {
                return NotFound("Participante no encontrado.");
            }

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

            await _participanteRepository.AddAsync(participante);

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
            var participante = await _participanteRepository.GetByIdAsync(id);

            if (participante == null)
            {
                return NotFound("Participante no encontrado.");
            }

            participante.FullName = dto.FullName;
            participante.IdentificationId = dto.IdentificationId;
            participante.PhoneNumber = dto.PhoneNumber;
            participante.Email = dto.Email;

            await _participanteRepository.UpdateAsync(participante);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipante(int id)
        {
            var participante = await _participanteRepository.GetByIdAsync(id);

            if (participante == null)
            {
                return NotFound("Participante no encontrado.");
            }

            await _participanteRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}