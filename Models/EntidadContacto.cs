using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFormacion.Models
{
    public class EntidadContacto
    {
        [Required(ErrorMessage = "Este es un campo necesario")]
        [RegularExpression("([0-9]|L|K|X|Z|M){1}[0-9]{7}[A-Z]{1}", ErrorMessage = "9 Carácteres")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EntidadID { get; set; }
        [ForeignKey("EntidadID")]
        public Entidad Entidad { get; set; }

        [Required(ErrorMessage = "Este es un campo necesario")]
        [RegularExpression("([0-9]|L|K|X|Z|M){1}[0-9]{7}[A-Z]{1}", ErrorMessage = "9 Carácteres")]
        public string ContactoID { get; set; }
        [ForeignKey("ContactoID")]
        public Contacto Contacto { get; set; }
    }
}
