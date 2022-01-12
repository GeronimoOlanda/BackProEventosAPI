using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSQLServer.Models
{
    public class Produtos
    {
        public int ClientId { get; set; }
        public string Cliente { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

    public class Invoices
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Produtos Produtos { get; set; }

    }
}
