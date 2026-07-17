using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestorDeEventos.Application.Contract;
using GestorDeEventos.Application.Dtos.Evento;

namespace GestorDeEventosSolucion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoDto>>> Get()
        {
            var dtos = await _eventoService.ObtenerTodosLosEventosAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDto>> GetById(int id)
        {
            var dto = await _eventoService.ObtenerEventoPorIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<EventoDto>> Post(EventoDto d)
        {
            var resultDto = await _eventoService.CrearEventoAsync(d);
            return Ok(resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoDto d)
        {
            var eventoExistente = await _eventoService.ObtenerEventoPorIdAsync(id);
            if (eventoExistente == null)
            {
                return NotFound();
            }

            d.Id = id;
            await _eventoService.ActualizarEventoAsync(d);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventoExistente = await _eventoService.ObtenerEventoPorIdAsync(id);
            if (eventoExistente == null)
            {
                return NotFound();
            }

            await _eventoService.EliminarEventoAsync(id);
            return NoContent();
        }
    }
}