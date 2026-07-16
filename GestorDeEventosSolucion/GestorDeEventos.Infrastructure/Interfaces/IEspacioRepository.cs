using GestorDeEventos.Domain.Entities;

namespace GestorDeEventos.Infrastructure.Interfaces
{
    public interface IEspacioRepository
    {
        Task<IEnumerable<Espacio>> GetAllAsync();
        Task<Espacio?> GetByIdAsync(int id);
        Task AddAsync(Espacio entity);
        Task UpdateAsync(Espacio entity);
        Task DeleteAsync(int id);
    }
}