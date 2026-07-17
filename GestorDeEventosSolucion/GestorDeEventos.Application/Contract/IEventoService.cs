using System.Collections.Generic;
using System.Threading.Tasks;
using GestorDeEventos.Application.Dtos.Evento;

namespace GestorDeEventos.Application.Contract
{
    public interface IEventoService
    {
        Task<IEnumerable<EventoDto>> ObtenerTodosLosEventosAsync();
        Task<EventoDto?> ObtenerEventoPorIdAsync(int id);
        Task<EventoDto> CrearEventoAsync(EventoDto eventoDto);
        Task ActualizarEventoAsync(EventoDto eventoDto);
        Task EliminarEventoAsync(int id);
    }
}