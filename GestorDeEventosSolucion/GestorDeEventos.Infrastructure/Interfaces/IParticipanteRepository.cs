using GestorDeEventos.Domain.Entities;

namespace GestorDeEventos.Infrastructure.Interfaces
{
    public interface IParticipanteRepository
    {
        Task<IEnumerable<Participante>> GetAllAsync();
        Task<Participante?> GetByIdAsync(int id);
        Task AddAsync(Participante entity);
        Task UpdateAsync(Participante entity);
        Task DeleteAsync(int id);
    }
}