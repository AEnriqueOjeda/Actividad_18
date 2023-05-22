using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_18.Shared.Models
{
    public class Usuarios
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "El Nombre no debe estar vacio"), MaxLength(100)]
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El Telefono no debe estar vacio"), MaxLength(12), Phone]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El Correo no debe estar vacio"), MaxLength(100), EmailAddress]
        public string? Correo { get; set; }

        public virtual ICollection<Prestamos>? Prestamos { get; set;}
    }
}
