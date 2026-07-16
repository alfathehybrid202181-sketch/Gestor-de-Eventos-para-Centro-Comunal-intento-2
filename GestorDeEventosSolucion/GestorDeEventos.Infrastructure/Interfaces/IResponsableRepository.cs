using GestorDeEventos.Domain.Entities;

namespace GestorDeEventos.Infrastructure.Interfaces
{
    public interface IResponsableRepository
    {
        Task<IEnumerable<Responsable>> GetAllAsync();
        Task<Responsable?> GetByIdAsync(int id);
        Task AddAsync(Responsable entity);
        Task UpdateAsync(Responsable entity);
        Task DeleteAsync(int id);
    }
}