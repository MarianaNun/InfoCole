using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class Linea
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [MaxLength(50,ErrorMessage ="El campo {0} no puede exeder los {1} caracteres")]
        public string Nombre { get; set; }


        public virtual ICollection<Comentario> Comentario { get; set; }
    }
}