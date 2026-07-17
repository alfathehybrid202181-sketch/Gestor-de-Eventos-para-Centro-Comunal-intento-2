using GestorDeEventos.Application.Dtos.Espacio;

namespace GestorDeEventos.Application.Contract
{
    public interface IEspacioService
    {
        Task<IEnumerable<EspacioDto>> ObtenerTodosLosEspaciosAsync();
        Task<EspacioDto?> ObtenerEspacioPorIdAsync(int id);
        Task<EspacioDto> CrearEspacioAsync(EspacioDto espacioDto);
        Task ActualizarEspacioAsync(EspacioDto espacioDto);
        Task EliminarEspacioAsync(int id);
    }
}