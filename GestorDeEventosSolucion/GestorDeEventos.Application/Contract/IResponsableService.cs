using System.Collections.Generic;
using System.Threading.Tasks;
using GestorDeEventos.Application.Dtos.Responsable;

namespace GestorDeEventos.Application.Contract
{
    public interface IResponsableService
    {
        Task<IEnumerable<ResponsableDto>> ObtenerTodosLosResponsablesAsync();
        Task<ResponsableDto?> ObtenerResponsablePorIdAsync(int id);
        Task<ResponsableDto> CrearResponsableAsync(ResponsableDto responsableDto);
        Task ActualizarResponsableAsync(ResponsableDto responsableDto);
        Task EliminarResponsableAsync(int id);
    }
}