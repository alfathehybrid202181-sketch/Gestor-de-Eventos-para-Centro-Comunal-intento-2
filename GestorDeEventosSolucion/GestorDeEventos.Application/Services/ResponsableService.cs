using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorDeEventos.Application.Contract;
using GestorDeEventos.Application.Dtos.Responsable;
using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Interfaces;

namespace GestorDeEventos.Application.Services
{
    public class ResponsableService : IResponsableService
    {
        private readonly IResponsableRepository _responsableRepository;

        public ResponsableService(IResponsableRepository responsableRepository)
        {
            _responsableRepository = responsableRepository;
        }

        public async Task<IEnumerable<ResponsableDto>> ObtenerTodosLosResponsablesAsync()
        {
            var responsables = await _responsableRepository.GetAllAsync();

            return responsables.Select(r => new ResponsableDto
            {
                Id = r.Id,
                FullName = r.FullName,
                Role = r.Role,
                PhoneNumber = r.PhoneNumber,
                Email = r.Email
            });
        }

        public async Task<ResponsableDto?> ObtenerResponsablePorIdAsync(int id)
        {
            var r = await _responsableRepository.GetByIdAsync(id);
            if (r == null) return null;

            return new ResponsableDto
            {
                Id = r.Id,
                FullName = r.FullName,
                Role = r.Role,
                PhoneNumber = r.PhoneNumber,
                Email = r.Email
            };
        }

        public async Task<ResponsableDto> CrearResponsableAsync(ResponsableDto responsableDto)
        {
            var nuevoResponsable = new Responsable
            {
                FullName = responsableDto.FullName,
                Role = responsableDto.Role,
                PhoneNumber = responsableDto.PhoneNumber,
                Email = responsableDto.Email
            };

            await _responsableRepository.AddAsync(nuevoResponsable);

            responsableDto.Id = nuevoResponsable.Id;
            return responsableDto;
        }

        public async Task ActualizarResponsableAsync(ResponsableDto responsableDto)
        {
            var responsableExistente = await _responsableRepository.GetByIdAsync(responsableDto.Id);
            if (responsableExistente != null)
            {
                responsableExistente.FullName = responsableDto.FullName;
                responsableExistente.Role = responsableDto.Role;
                responsableExistente.PhoneNumber = responsableDto.PhoneNumber;
                responsableExistente.Email = responsableDto.Email;

                await _responsableRepository.UpdateAsync(responsableExistente);
            }
        }

        public async Task EliminarResponsableAsync(int id)
        {
            await _responsableRepository.DeleteAsync(id);
        }
    }
}