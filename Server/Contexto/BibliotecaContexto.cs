using Actividad_18.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad_18.Server.Contexto
{
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto(DbContextOptions<BibliotecaContexto> options):base(options) 
        { 

        }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
    }
}
