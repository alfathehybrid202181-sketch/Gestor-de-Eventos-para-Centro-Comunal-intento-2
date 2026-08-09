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
                Email = p.Email,
                EventoId = p.EventoId
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
                Email = p.Email,
                EventoId = p.EventoId
            };
        }

        public async Task<ParticipanteDto> CrearParticipanteAsync(ParticipanteDto dto)
        {
            var entidad = new Participante
            {
                FullName = dto.FullName,
                IdentificationId = dto.IdentificationId,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                EventoId = dto.EventoId
            };

            await _participanteRepository.AddAsync(entidad);

            dto.Id = entidad.Id;
            return dto;
        }

        public async Task ActualizarParticipanteAsync(ParticipanteDto dto)
        {
            var entidad = await _participanteRepository.GetByIdAsync(dto.Id);
            if (entidad != null)
            {
                entidad.FullName = dto.FullName;
                entidad.IdentificationId = dto.IdentificationId;
                entidad.PhoneNumber = dto.PhoneNumber;
                entidad.Email = dto.Email;
                entidad.EventoId = dto.EventoId;

                await _participanteRepository.UpdateAsync(entidad);
            }
        }

        public async Task EliminarParticipanteAsync(int id)
        {
            await _participanteRepository.DeleteAsync(id);
        }
    }
}