using GestorDeEventos.Domain.Core;

namespace GestorDeEventos.Domain.Entities
{
    public class Participante : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string IdentificationId { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Evento> Eventos { get; set; } = new();
    }
}