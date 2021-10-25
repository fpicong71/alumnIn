using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFormacion.Models
{
    public class Historial
    {
        [Required(ErrorMessage = "Este es un campo necesario")]
        [Display(Name ="ID Contacto")]
        public int HistorialID { get; set; }

        [Required(ErrorMessage = "Este es un campo necesario")]
        [Display(Name = "Correo del Alumno")]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)*$", ErrorMessage = "Escriba un correo válido")]
        public string AlumnoID { get; set; }
        [ForeignKey("AlumnoID")]
        public Alumno Alumno { get; set; }

        [Required(ErrorMessage = "Este es un campo necesario")]
        [Display(Name = "Contacto ID")]
        [RegularExpression("([0-9]|L|K|X|Z|M){1}[0-9]{7}[A-Z]{1}", ErrorMessage = "9 Carácteres")]
        public string ContactoID { get; set; }
        [ForeignKey("ContactoID")]
        public Contacto Contacto { get; set; }

        [Required(ErrorMessage = "Este es un campo necesario")]
        [Display(Name = "Curso")]
        public string CursoID { get; set; }
        [ForeignKey("CursoID")]
        public Curso Curso { get; set; }

        [Required(ErrorMessage = "Este es un campo necesario")]
        [Display(Name = "Fecha contacto")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Medio contacto")]
        public string Medio { get; set; }

        [Display(Name = "Mensaje")]
        public string Mensaje { get; set; }

    }
}
