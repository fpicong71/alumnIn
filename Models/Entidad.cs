using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFormacion.Models
{
    public class Entidad
    {
        //[Key]
        [Display(Name = "NIF")]
        [Required(ErrorMessage = "Este es un campo necesario")]
        [RegularExpression("([0-9]|L|K|X|Z|M){1}[0-9]{7}[A-Z]{1}", ErrorMessage = "9 Carácteres")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String EntidadID { get; set; }

        [Display(Name = "Razón Social")]
        [Required(ErrorMessage = "Este es un campo necesario")]
        public String RazonSocial { get; set; }

        [Display(Name = "Dirección")]
        public String Direccion { get; set; }

        [Display(Name = "CP")]
        public int CodigoPostal { get; set; }

        public ICollection<EntidadContacto> EntidadContactos { get; set; }

        public ICollection<CursoEntidad> CursoEntidades { get; set; }
    }
}
