using Microsoft.EntityFrameworkCore;
using proEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class EventoPersistence : IEventosPersistence
    {
        private readonly ProEventosContext _context;
        //inicializando nosso contrutor e pegando o contexto dele de ProEventosCOntext
        public EventoPersistence(ProEventosContext context)
        {
            _context = context;
        }



        public async Task<Evento[]> GetEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include( e=> e.Lotes)
                                                       .Include(e => e.RedesSociais);
            
            //caso a pessoa queira incluir palestrante
            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestranteEventos)
                              .ThenInclude(pe => pe.Palestrante);

            }
            query = query.OrderBy(e => e.EventoId);
            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetEventosAllByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
                                                       .Include(e => e.RedesSociais);


            //caso a pessoa queira incluir palestrante
            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestranteEventos)
                              .ThenInclude(pe => pe.Palestrante);

            }
            query = query.OrderBy(e => e.EventoId).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
            
        }

        public async Task<Evento[]> GetEventosByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
                                                       .Include(e => e.RedesSociais);


            //caso a pessoa queira incluir palestrante
            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestranteEventos)
                              .ThenInclude(pe => pe.Palestrante);

            }
            query = query.OrderBy(e => e.EventoId).Where(e => e.EventoId == EventoId);
            return await query.ToArrayAsync();
        }

      


   
    }
}
