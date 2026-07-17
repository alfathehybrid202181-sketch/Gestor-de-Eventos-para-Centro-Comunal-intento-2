namespace GestorDeEventosSolucion.Dtos.espacio
{
    public class EspacioDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int MaxCapacity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
