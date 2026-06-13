using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorDeEventosSolucion.Data;
using GestorDeEventosSolucion.Molder;
using GestorDeEventosSolucion.Molder.Dtos;

namespace GestorDeEventosSolucion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EspaciosController : ControllerBase
{
    private readonly DataContext _context;

    public EspaciosController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EspacioDto>>> Get()
    {
        var espacios = await _context.Espacios.ToListAsync();
        var dtos = espacios.Select(e => new EspacioDto
        {
            Id = e.Id,
            Name = e.Name,
            Location = e.Location,
            MaxCapacity = e.MaxCapacity,
            IsAvailable = e.IsAvailable
        });
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EspacioDto>> Get(int id)
    {
        var e = await _context.Espacios.FindAsync(id);
        if (e == null) return NotFound();

        return Ok(new EspacioDto
        {
            Id = e.Id,
            Name = e.Name,
            Location = e.Location,
            MaxCapacity = e.MaxCapacity,
            IsAvailable = e.IsAvailable
        });
    }

    [HttpPost]
    public async Task<ActionResult<EspacioDto>> Post(CreateEspacioDto d)
    {
        var e = new Espacio
        {
            Name = d.Name,
            Location = d.Location,
            MaxCapacity = d.MaxCapacity,
            IsAvailable = d.IsAvailable
        };

        _context.Espacios.Add(e);
        await _context.SaveChangesAsync();

        return Ok(new EspacioDto
        {
            Id = e.Id,
            Name = d.Name,
            Location = d.Location,
            MaxCapacity = d.MaxCapacity,
            IsAvailable = d.IsAvailable
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateEspacioDto d)
    {
        var e = await _context.Espacios.FindAsync(id);
        if (e == null) return NotFound();

        e.Name = d.Name;
        e.Location = d.Location;
        e.MaxCapacity = d.MaxCapacity;
        e.IsAvailable = d.IsAvailable;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var e = await _context.Espacios.FindAsync(id);
        if (e == null) return NotFound();

        _context.Espacios.Remove(e);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}