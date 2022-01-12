using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSQLServer.Models;

namespace WebApiSQLServer.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Produtos> Cliente;
    }
}
