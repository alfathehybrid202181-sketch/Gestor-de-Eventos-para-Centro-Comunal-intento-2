using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Core;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorDeEventos.Infrastructure.Repositories
{
    public class ParticipanteRepository : BaseRepository<Participante>, IParticipanteRepository
    {
        public ParticipanteRepository(DataContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Participante>> GetAllAsync()
        {
            return await _context.Participantes
                .AsNoTracking()
                .ToListAsync();
        }
    }
}