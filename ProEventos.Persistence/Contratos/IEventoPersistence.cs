using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
   public interface IEventosPersistence
    {
        //Eventos
        Task<Evento[]> GetEventosAllByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> GetEventosByIdAsync(int EventoId, bool includePalestrantes = false);

     
    }
}
