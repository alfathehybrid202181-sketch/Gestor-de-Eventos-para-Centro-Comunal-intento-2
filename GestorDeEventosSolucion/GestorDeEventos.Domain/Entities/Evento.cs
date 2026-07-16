using GestorDeEventos.Domain.Core;

namespace GestorDeEventos.Domain.Entities
{
    public class Evento : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Scheduling { get; set; }
        public int EspacioId { get; set; }
        public int ResponsableId { get; set; }
    }
}