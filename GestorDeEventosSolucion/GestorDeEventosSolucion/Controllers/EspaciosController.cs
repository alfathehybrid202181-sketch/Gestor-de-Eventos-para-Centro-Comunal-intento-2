using Microsoft.AspNetCore.Mvc;
using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventosSolucion.Dtos;

namespace GestorDeEventosSolucion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspaciosController : ControllerBase
    {
        private readonly IEspacioRepository _espacioRepository;

        public EspaciosController(IEspacioRepository espacioRepository)
        {
            _espacioRepository = espacioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspacioDto>>> Get()
        {
            var espacios = await _espacioRepository.GetAllAsync();

            var dtos = espacios.Select(e => new EspacioDto
            {
                Id = e.Id,
                Name = e.Name,
                Location = e.Location,
                MaxCapacity = e.MaxCapacity,
                IsAvailable = e.IsAvailable
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EspacioDto>> GetById(int id)
        {
            var espacio = await _espacioRepository.GetByIdAsync(id);
            if (espacio == null)
            {
                return NotFound();
            }

            var dto = new EspacioDto
            {
                Id = espacio.Id,
                Name = espacio.Name,
                Location = espacio.Location,
                MaxCapacity = espacio.MaxCapacity,
                IsAvailable = espacio.IsAvailable
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<EspacioDto>> Post(CreateEspacioDto d)
        {
            var nuevoEspacio = new Espacio
            {
                Name = d.Name,
                Location = d.Location,
                MaxCapacity = d.MaxCapacity,
                IsAvailable = d.IsAvailable
            };

            await _espacioRepository.AddAsync(nuevoEspacio);

            var resultDto = new EspacioDto
            {
                Id = nuevoEspacio.Id,
                Name = nuevoEspacio.Name,
                Location = nuevoEspacio.Location,
                MaxCapacity = nuevoEspacio.MaxCapacity,
                IsAvailable = nuevoEspacio.IsAvailable
            };

            return Ok(resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateEspacioDto d)
        {
            var espacioExistente = await _espacioRepository.GetByIdAsync(id);
            if (espacioExistente == null)
            {
                return NotFound();
            }

            espacioExistente.Name = d.Name;
            espacioExistente.Location = d.Location;
            espacioExistente.MaxCapacity = d.MaxCapacity;
            espacioExistente.IsAvailable = d.IsAvailable;

            await _espacioRepository.UpdateAsync(espacioExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var espacio = await _espacioRepository.GetByIdAsync(id);
            if (espacio == null)
            {
                return NotFound();
            }

            await _espacioRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}