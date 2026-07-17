namespace GestorDeEventosSolucion.Dtos.espacio
{
    public class UpdateEspacioDto
    {
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int MaxCapacity { get; set; }
    public bool IsAvailable { get; set; }
    }
}
