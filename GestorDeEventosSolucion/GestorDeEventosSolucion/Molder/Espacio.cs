using System.Security.Cryptography;

namespace GestorDeEventosSolucion.Molder
{
    public class Espacio
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int MaxCapacity { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
