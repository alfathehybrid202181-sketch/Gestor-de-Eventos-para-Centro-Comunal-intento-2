using Microsoft.EntityFrameworkCore;
using GestorDeEventosSolucion.Molder; 

namespace GestorDeEventosSolucion.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Espacio> Espacios { get; set; }
    public DbSet<Evento> Eventos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Evento>()
         .HasOne<Espacio>()
         .WithMany()
         .HasForeignKey(e => e.EspacioId)
         .OnDelete(DeleteBehavior.Restrict);
    }
}