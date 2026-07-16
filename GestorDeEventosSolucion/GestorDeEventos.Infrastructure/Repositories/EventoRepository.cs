using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Core;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventos.Infrastructure.Context;

namespace GestorDeEventos.Infrastructure.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        public EventoRepository(DataContext context) : base(context)
        {
        }
    }
}