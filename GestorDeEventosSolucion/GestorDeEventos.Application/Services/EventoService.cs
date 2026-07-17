using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorDeEventos.Application.Contract;
using GestorDeEventos.Application.Dtos.Evento;
using GestorDeEventos.Domain.Entities;
using GestorDeEventos.Infrastructure.Interfaces;

namespace GestorDeEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<IEnumerable<EventoDto>> ObtenerTodosLosEventosAsync()
        {
            var eventos = await _eventoRepository.GetAllAsync();

            return eventos.Select(e => new EventoDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Scheduling = e.Scheduling,
                EspacioId = e.EspacioId,
                ResponsableId = e.ResponsableId
            });
        }

        public async Task<EventoDto?> ObtenerEventoPorIdAsync(int id)
        {
            var e = await _eventoRepository.GetByIdAsync(id);
            if (e == null) return null;

            return new EventoDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Scheduling = e.Scheduling,
                EspacioId = e.EspacioId,
                ResponsableId = e.ResponsableId
            };
        }

        public async Task<EventoDto> CrearEventoAsync(EventoDto eventoDto)
        {
            var nuevoEvento = new Evento
            {
                Name = eventoDto.Name,
                Description = eventoDto.Description,
                Scheduling = eventoDto.Scheduling,
                EspacioId = eventoDto.EspacioId,
                ResponsableId = eventoDto.ResponsableId
            };

            await _eventoRepository.AddAsync(nuevoEvento);

            eventoDto.Id = nuevoEvento.Id;
            return eventoDto;
        }

        public async Task ActualizarEventoAsync(EventoDto eventoDto)
        {
            var eventoExistente = await _eventoRepository.GetByIdAsync(eventoDto.Id);
            if (eventoExistente != null)
            {
                eventoExistente.Name = eventoDto.Name;
                eventoExistente.Description = eventoDto.Description;
                eventoExistente.Scheduling = eventoDto.Scheduling;
                eventoExistente.EspacioId = eventoDto.EspacioId;
                eventoExistente.ResponsableId = eventoDto.ResponsableId;

                await _eventoRepository.UpdateAsync(eventoExistente);
            }
        }

        public async Task EliminarEventoAsync(int id)
        {
            await _eventoRepository.DeleteAsync(id);
        }
    }
}