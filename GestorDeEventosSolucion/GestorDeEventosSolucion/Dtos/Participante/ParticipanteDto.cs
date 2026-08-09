namespace GestorDeEventosSolucion.Dtos.Participante
{
    public class ParticipanteDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string IdentificationId { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int EventoId { get; set; }
    }
}