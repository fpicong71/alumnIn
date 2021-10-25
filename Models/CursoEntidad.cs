using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFormacion.Models
{
    public class CursoEntidad
    {
        [Required(ErrorMessage = "Este es un campo necesario")]
        public string EntidadID { get; set; }
        [ForeignKey("EntidadID")]
        public Entidad Entidad { get; set; }

        [Required(ErrorMessage = "Este es un campo necesario")]
        public string CursoID { get; set; }
        [ForeignKey("CursoID")]
        public Curso Curso { get; set; }
    }
}
