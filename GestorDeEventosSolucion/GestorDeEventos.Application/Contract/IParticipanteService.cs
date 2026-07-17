using System.Collections.Generic;
using System.Threading.Tasks;
using GestorDeEventos.Application.Dtos.Participante;

namespace GestorDeEventos.Application.Contract
{
    public interface IParticipanteService
    {
        Task<IEnumerable<ParticipanteDto>> ObtenerTodosLosParticipantesAsync();
        Task<ParticipanteDto?> ObtenerParticipantePorIdAsync(int id);
        Task<ParticipanteDto> CrearParticipanteAsync(ParticipanteDto participanteDto);
        Task ActualizarParticipanteAsync(ParticipanteDto participanteDto);
        Task EliminarParticipanteAsync(int id);
    }
}