using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Core;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventos.Infrastructure.Context;

namespace GestorDeEventos.Infrastructure.Repositories
{
    public class ParticipanteRepository : BaseRepository<Participante>, IParticipanteRepository
    {
        public ParticipanteRepository(DataContext context) : base(context)
        {
        }
    }
}