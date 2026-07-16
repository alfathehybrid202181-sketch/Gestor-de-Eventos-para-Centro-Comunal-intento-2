using GestorDeEventos.Domain.Core;

namespace GestorDeEventos.Domain.Entities
{
    public class Espacio : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int MaxCapacity { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}