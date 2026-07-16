using Microsoft.AspNetCore.Mvc;
using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventosSolucion.Dtos;

namespace GestorDeEventosSolucion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventosController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoDto>>> Get()
        {
            var databaseEventos = await _eventoRepository.GetAllAsync();

            var dtos = databaseEventos.Select(e => new EventoDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Scheduling = e.Scheduling,
                EspacioId = e.EspacioId
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDto>> GetById(int id)
        {
            var e = await _eventoRepository.GetByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }

            var dto = new EventoDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Scheduling = e.Scheduling,
                EspacioId = e.EspacioId
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<EventoDto>> Post(CreateEventoDto d)
        {
            var e = new Evento
            {
                Name = d.Name,
                Description = d.Description,
                Scheduling = d.Scheduling,
                EspacioId = d.EspacioId
            };

            await _eventoRepository.AddAsync(e);

            var resultDto = new EventoDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Scheduling = e.Scheduling,
                EspacioId = e.EspacioId
            };

            return Ok(resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateEventoDto d)
        {
            var e = await _eventoRepository.GetByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }

            e.Name = d.Name;
            e.Description = d.Description;
            e.Scheduling = d.Scheduling;
            e.EspacioId = d.EspacioId;

            await _eventoRepository.UpdateAsync(e);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await _eventoRepository.GetByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }

            await _eventoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}