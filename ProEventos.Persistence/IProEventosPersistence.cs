using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
   public interface IProEventosPersistence
    {
        //sao nossos indices gerais, todo e qualquer adicionar, deletar e salvar e update, ele usara esses metodos
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Evento[]> GetEventosAllByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetEventosAsync(bool includePalestrantes);
        Task<Evento[]> GetEventosByIdAsync(int EventoId, bool includePalestrantes);

        //Palestrantes
        Task<Evento[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Evento[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Evento[]> GetAllPalestrantesByIdAsync(int PalestranteId, bool includeEventos);
    }
}
