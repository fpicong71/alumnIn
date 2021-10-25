using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFormacion.Models
{
    public class Curso
    {
        [Display(Name = "Código de Curso")]
        [Required(ErrorMessage = "Este es un campo necesario")]
        [MaxLength(15, ErrorMessage = "Un máximo de 15 caracteres"), MinLength(3, ErrorMessage = "Un mínimo de 3 caracteres")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CursoID { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este es un campo necesario")]
        public string NombreCurso { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(1000, ErrorMessage = "Un máximo de 1000 caracteres"), MinLength(5, ErrorMessage = "Un mínimo de 5 caracteres")]
        public string DescripcionCurso { get; set; }

        public ICollection<CursoEntidad> CursoEntidades { get; set; }

        public ICollection<Historial> Historiales { get; set; }
    }
}
