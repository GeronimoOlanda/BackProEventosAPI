

using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Evento
    {
        public int EventoId  {get; set;}
        public  string Local {get; set;}
        public DateTime? DataEvento  {get; set;}
        public string Tema {get; set;}
        public int QuantidadePessoas {get; set;}
        public  string ImagemURL {get; set;}

        public int Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }

        public IEnumerable<RedeSocial> RedesSociais { get; set; }

        public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }
    }
}
