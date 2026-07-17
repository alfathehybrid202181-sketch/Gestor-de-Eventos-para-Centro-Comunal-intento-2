using System;

namespace GestorDeEventos.Application.Dtos.Evento
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Scheduling { get; set; }
        public int EspacioId { get; set; }
        public int ResponsableId { get; set; }
    }
}