using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IEventosService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int eventoId, Evento model);
        Task<bool> DeleteEventos(int eventoId);

        Task<Evento[]> GetEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> GetEventosAllByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetEventosByIdAsync(int EventoId, bool includePalestrantes = false);
    }
}
