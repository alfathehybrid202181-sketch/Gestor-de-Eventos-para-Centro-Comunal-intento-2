namespace GestorDeEventosSolucion.Dtos.Evento
{
    public class CreateEventoDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Scheduling { get; set; }
        public int EspacioId { get; set; }
    }
}
