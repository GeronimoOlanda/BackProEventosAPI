using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proEventos.Persistence.Contexto;
using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proEventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
       
        private readonly ProEventosContext _context;
        public EventoController(ProEventosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> GetAllEventos()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post(string value)
        {
            return value;
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de put {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Esse é o nosso delete {id}";
        }
    }
}
