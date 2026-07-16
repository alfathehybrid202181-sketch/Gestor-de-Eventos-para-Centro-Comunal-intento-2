using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Core;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventos.Infrastructure.Context;

namespace GestorDeEventos.Infrastructure.Repositories
{
    public class ResponsableRepository : BaseRepository<Responsable>, IResponsableRepository
    {
        public ResponsableRepository(DataContext context) : base(context)
        {
        }
    }
}