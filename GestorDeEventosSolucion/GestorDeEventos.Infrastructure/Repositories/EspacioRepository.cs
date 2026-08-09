using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Core;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorDeEventos.Infrastructure.Repositories
{
    public class EspacioRepository : BaseRepository<Espacio>, IEspacioRepository
    {
        public EspacioRepository(DataContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Espacio>> GetAllAsync()
        {
            return await _context.Espacios
                .AsNoTracking()
                .ToListAsync();
        }
    }
}