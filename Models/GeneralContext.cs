using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace diaD.Models
{
    public class GeneralContext : DbContext
    {
        public GeneralContext(DbContextOptions<GeneralContext> options)
            : base(options)
        { }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}