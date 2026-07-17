using GestorDeEventos.Application.Contract;
using GestorDeEventos.Application.Dtos.Espacio;
using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Interfaces;

namespace GestorDeEventos.Application.Services
{
    public class EspacioService : IEspacioService
    {
        private readonly IEspacioRepository _espacioRepository;

        public EspacioService(IEspacioRepository espacioRepository)
        {
            _espacioRepository = espacioRepository;
        }

        public async Task<IEnumerable<EspacioDto>> ObtenerTodosLosEspaciosAsync()
        {
            var espacios = await _espacioRepository.GetAllAsync();

            return espacios.Select(e => new EspacioDto
            {
                Id = e.Id,
                Name = e.Name,
                Location = e.Location,
                MaxCapacity = e.MaxCapacity,
                IsAvailable = e.IsAvailable
            });
        }

        public async Task<EspacioDto?> ObtenerEspacioPorIdAsync(int id)
        {
            var e = await _espacioRepository.GetByIdAsync(id);
            if (e == null) return null;

            return new EspacioDto
            {
                Id = e.Id,
                Name = e.Name,
                Location = e.Location,
                MaxCapacity = e.MaxCapacity,
                IsAvailable = e.IsAvailable
            };
        }

        public async Task<EspacioDto> CrearEspacioAsync(EspacioDto espacioDto)
        {
            var nuevoEspacio = new Espacio
            {
                Name = espacioDto.Name,
                Location = espacioDto.Location,
                MaxCapacity = espacioDto.MaxCapacity,
                IsAvailable = espacioDto.IsAvailable
            };

            await _espacioRepository.AddAsync(nuevoEspacio);

            espacioDto.Id = nuevoEspacio.Id;
            return espacioDto;
        }

        public async Task ActualizarEspacioAsync(EspacioDto espacioDto)
        {
            var espacioExistente = await _espacioRepository.GetByIdAsync(espacioDto.Id);
            if (espacioExistente != null)
            {
                espacioExistente.Name = espacioDto.Name;
                espacioExistente.Location = espacioDto.Location;
                espacioExistente.MaxCapacity = espacioDto.MaxCapacity;
                espacioExistente.IsAvailable = espacioDto.IsAvailable;

                await _espacioRepository.UpdateAsync(espacioExistente);
            }
        }

        public async Task EliminarEspacioAsync(int id)
        {
            await _espacioRepository.DeleteAsync(id);
        }
    }
}