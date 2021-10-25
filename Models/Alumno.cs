using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFormacion.Models
{
    public class Alumno
    {
        [Display(Name = "Correo ID")]
        [Required(ErrorMessage = "Este es un campo necesario")]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)*$", ErrorMessage = "Escriba un correo válido")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AlumnoID { get; set; }

        [Required(ErrorMessage = "Este es un campo necesario")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Este es un campo necesario")]
        public string Apellido1 { get; set; }

        [Display(Name = "Apellido")]
        public string Apellido2 { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Este es un campo necesario")]
        public string Telefono { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "C.P.")]
        public int CodigoPostal { get; set; }

        public ICollection<Historial> Historiales { get; set; }
    }
}
