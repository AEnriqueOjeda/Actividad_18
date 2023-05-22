using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_18.Shared.Models
{
    public class Prestamos
    {
        public int Id { get; set; }
        public string codigo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public int? UsuariosId { get; set; }
        public virtual Usuarios? Usuario { get; set;}

        public virtual ICollection<Libros>? Libro { get; set; }

    }
}
