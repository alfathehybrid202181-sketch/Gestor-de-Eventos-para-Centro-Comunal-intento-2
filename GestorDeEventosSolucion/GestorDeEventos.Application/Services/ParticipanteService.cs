using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorDeEventos.Application.Contract;
using GestorDeEventos.Application.Dtos.Participante;
using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Interfaces;

namespace GestorDeEventos.Application.Services
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IParticipanteRepository _participanteRepository;

        public ParticipanteService(IParticipanteRepository participanteRepository)
        {
            _participanteRepository = participanteRepository;
        }

        public async Task<IEnumerable<ParticipanteDto>> ObtenerTodosLosParticipantesAsync()
        {
            var participantes = await _participanteRepository.GetAllAsync();

            return participantes.Select(p => new ParticipanteDto
            {
                Id = p.Id,
                FullName = p.FullName,
                IdentificationId = p.IdentificationId,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email
            });
        }

        public async Task<ParticipanteDto?> ObtenerParticipantePorIdAsync(int id)
        {
            var p = await _participanteRepository.GetByIdAsync(id);
            if (p == null) return null;

            return new ParticipanteDto
            {
                Id = p.Id,
                FullName = p.FullName,
                IdentificationId = p.IdentificationId,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email
            };
        }

        public async Task<ParticipanteDto> CrearParticipanteAsync(ParticipanteDto participanteDto)
        {
            var nuevoParticipante = new Participante
            {
                FullName = participanteDto.FullName,
                IdentificationId = participanteDto.IdentificationId,
                PhoneNumber = participanteDto.PhoneNumber,
                Email = participanteDto.Email
            };

            await _participanteRepository.AddAsync(nuevoParticipante);

            participanteDto.Id = nuevoParticipante.Id;
            return participanteDto;
        }

        public async Task ActualizarParticipanteAsync(ParticipanteDto participanteDto)
        {
            var participanteExistente = await _participanteRepository.GetByIdAsync(participanteDto.Id);
            if (participanteExistente != null)
            {
                participanteExistente.FullName = participanteDto.FullName;
                participanteExistente.IdentificationId = participanteDto.IdentificationId;
                participanteExistente.PhoneNumber = participanteDto.PhoneNumber;
                participanteExistente.Email = participanteDto.Email;

                await _participanteRepository.UpdateAsync(participanteExistente);
            }
        }

        public async Task EliminarParticipanteAsync(int id)
        {
            await _participanteRepository.DeleteAsync(id);
        }
    }
}