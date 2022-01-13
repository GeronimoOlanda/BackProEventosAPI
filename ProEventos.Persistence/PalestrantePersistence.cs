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
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosContext _context;
        //inicializando nosso contrutor e pegando o contexto dele de ProEventosCOntext
        public PalestrantePersistence(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSociais);


            //caso a pessoa queira incluir palestrante
            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                             .ThenInclude(e => e.Evento);

            }
            query = query.OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSociais);


            //caso a pessoa queira incluir palestrante
            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                             .ThenInclude(e => e.Evento);

            }
            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSociais);


            //caso a pessoa queira incluir palestrante
            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                             .ThenInclude(e => e.Evento);

            }
            query = query.OrderBy(p => p.Id).Where(p => p.Id == palestranteId);
            return await query.ToArrayAsync();
        }


    }
}
