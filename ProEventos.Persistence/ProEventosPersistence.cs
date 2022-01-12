using Microsoft.EntityFrameworkCore;
using proEventos.Persistence;
using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;
        //inicializando nosso contrutor e pegando o contexto dele de ProEventosCOntext
        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0 ;
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

      

        public Task<Evento[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllPalestrantesByIdAsync(int PalestranteId, bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            throw new NotImplementedException();
        }

   
    }
}
