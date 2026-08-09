using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Core;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorDeEventos.Infrastructure.Repositories
{
    public class ResponsableRepository : BaseRepository<Responsable>, IResponsableRepository
    {
        public ResponsableRepository(DataContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Responsable>> GetAllAsync()
        {
            return await _context.Responsables
                .AsNoTracking()
                .ToListAsync();
        }
    }
}