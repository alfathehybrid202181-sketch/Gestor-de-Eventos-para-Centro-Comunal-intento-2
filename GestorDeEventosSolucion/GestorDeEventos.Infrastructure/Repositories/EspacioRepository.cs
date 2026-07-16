using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Core;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventos.Infrastructure.Context;

namespace GestorDeEventos.Infrastructure.Repositories
{
    public class EspacioRepository : BaseRepository<Espacio>, IEspacioRepository
    {
        public EspacioRepository(DataContext context) : base(context)
        {
        }
    }
}