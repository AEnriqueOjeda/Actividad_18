using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_18.Shared.Models
{
    public class Libros
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string editorial { get; set; }
        public string autro { get; set; }
        public string ISBN { get; set; }
        public int ejemplares { get; set; }
        public int codigo { get; set; }

        public int? PrestamosId { get; set; }
        public virtual Prestamos? Prestamo { get; set; }
    }
}
