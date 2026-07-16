using Microsoft.EntityFrameworkCore;
using GestorDeEventos.Domain.Entities;

namespace GestorDeEventos.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Espacio> Espacios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
    }
}