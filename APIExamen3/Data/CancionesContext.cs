using Microsoft.EntityFrameworkCore;
using APIExamen3.Models;

namespace APIExamen3.Data
{
    public class CancionesContext:DbContext
    {
        public CancionesContext(DbContextOptions<CancionesContext> options) : base(options) { }

        public DbSet<Cancion> Canciones { get; set; }
    }
}
