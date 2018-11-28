using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class EstadoLinea
    {
        public int ID { get; set; }
        [Required]
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public virtual Linea Linea { get; set; }
    }
}