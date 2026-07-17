using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestorDeEventos.Application.Contract;
using GestorDeEventos.Application.Dtos.Espacio;

namespace GestorDeEventosSolucion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspaciosController : ControllerBase
    {
        private readonly IEspacioService _espacioService;

        public EspaciosController(IEspacioService espacioService)
        {
            _espacioService = espacioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspacioDto>>> Get()
        {
            var dtos = await _espacioService.ObtenerTodosLosEspaciosAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EspacioDto>> GetById(int id)
        {
            var dto = await _espacioService.ObtenerEspacioPorIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<EspacioDto>> Post(EspacioDto d)
        {
            var resultDto = await _espacioService.CrearEspacioAsync(d);
            return Ok(resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EspacioDto d)
        {
            var espacioExistente = await _espacioService.ObtenerEspacioPorIdAsync(id);
            if (espacioExistente == null)
            {
                return NotFound();
            }

            d.Id = id;
            await _espacioService.ActualizarEspacioAsync(d);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var espacioExistente = await _espacioService.ObtenerEspacioPorIdAsync(id);
            if (espacioExistente == null)
            {
                return NotFound();
            }

            await _espacioService.EliminarEspacioAsync(id);
            return NoContent();
        }
    }
}