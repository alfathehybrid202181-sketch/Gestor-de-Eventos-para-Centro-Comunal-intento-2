using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestorDeEventos.Application.Contract;
using GestorDeEventos.Application.Dtos.Participante;

namespace GestorDeEventosSolucion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantesController : ControllerBase
    {
        private readonly IParticipanteService _participanteService;

        public ParticipantesController(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipanteDto>>> GetParticipantes()
        {
            var dtos = await _participanteService.ObtenerTodosLosParticipantesAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipanteDto>> GetParticipante(int id)
        {
            var dto = await _participanteService.ObtenerParticipantePorIdAsync(id);
            if (dto == null)
            {
                return NotFound("Participante no encontrado.");
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ParticipanteDto>> PostParticipante(ParticipanteDto dto)
        {
            var resultDto = await _participanteService.CrearParticipanteAsync(dto);
            return CreatedAtAction(nameof(GetParticipante), new { id = resultDto.Id }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipante(int id, ParticipanteDto dto)
        {
            var participanteExistente = await _participanteService.ObtenerParticipantePorIdAsync(id);
            if (participanteExistente == null)
            {
                return NotFound("Participante no encontrado.");
            }

            dto.Id = id;
            await _participanteService.ActualizarParticipanteAsync(dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipante(int id)
        {
            var participanteExistente = await _participanteService.ObtenerParticipantePorIdAsync(id);
            if (participanteExistente == null)
            {
                return NotFound("Participante no encontrado.");
            }

            await _participanteService.EliminarParticipanteAsync(id);
            return NoContent();
        }
    }
}