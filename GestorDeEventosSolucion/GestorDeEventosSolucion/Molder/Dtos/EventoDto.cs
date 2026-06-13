namespace GestorDeEventosSolucion.Molder.Dtos
{
    public class EventoDto
    {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Scheduling { get; set; }
    public int EspacioId { get; set; }
    }
}
