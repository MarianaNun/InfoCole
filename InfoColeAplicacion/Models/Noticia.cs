using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class Noticia
    {
        
        public int NoticiaId { get; set; }

        [Required]
        [MaxLength(70,ErrorMessage ="El campo {0} no debe exeder los {1} caracteres")]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(115, ErrorMessage = "El campo {0} no debe exeder los {1} caracteres")]
        public string Descripcion { get; set; }

        public string LinkNoticia { get; set; }

        public string LinkImagen { get; set; }

        public DateTime FechaPublicacion { get; set; }


    }
}