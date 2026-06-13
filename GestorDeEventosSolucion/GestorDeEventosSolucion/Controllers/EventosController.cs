using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorDeEventosSolucion.Data;
using GestorDeEventosSolucion.Molder;
using GestorDeEventosSolucion.Molder.Dtos;

namespace GestorDeEventosSolucion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly DataContext _context;

    public EventosController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventoDto>>> Get()
    {
        var eventos = await _context.Eventos.ToListAsync();
        var dtos = eventos.Select(e => new EventoDto
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            Scheduling = e.Scheduling,
            EspacioId = e.EspacioId
        });
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventoDto>> Get(int id)
    {
        var e = await _context.Eventos.FindAsync(id);
        if (e == null) return NotFound();

        return Ok(new EventoDto
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            Scheduling = e.Scheduling,
            EspacioId = e.EspacioId
        });
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

        _context.Eventos.Add(e);
        await _context.SaveChangesAsync();

        return Ok(new EventoDto
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            Scheduling = e.Scheduling,
            EspacioId = e.EspacioId
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateEventoDto d)
    {
        var e = await _context.Eventos.FindAsync(id);
        if (e == null) return NotFound();

        e.Name = d.Name;
        e.Description = d.Description;
        e.Scheduling = d.Scheduling;
        e.EspacioId = d.EspacioId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var e = await _context.Eventos.FindAsync(id);
        if (e == null) return NotFound();

        _context.Eventos.Remove(e);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}