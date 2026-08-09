using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Core;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorDeEventos.Infrastructure.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        public EventoRepository(DataContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Evento>> GetAllAsync()
        {
            return await _context.Eventos
                .AsNoTracking()
                .ToListAsync();
        }
    }
}