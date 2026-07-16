using GestorDeEventos.Domain.Entities;

namespace GestorDeEventos.Infrastructure.Interfaces
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task AddAsync(Evento entity);
        Task UpdateAsync(Evento entity);
        Task DeleteAsync(int id);
    }
}