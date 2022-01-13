using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proEventos.Persistence.Contexto
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) {}
        public DbSet<Evento> Eventos {get;set;}
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // criando uma associação do eventoId com o Palestrante Id
            modelBuilder.Entity<PalestranteEvento>().HasKey(PE => new { PE.EventoId, PE.PalestranteId });
        }
    }
}
