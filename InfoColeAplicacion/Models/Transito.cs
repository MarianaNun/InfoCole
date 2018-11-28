using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class Transito
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "El campo contenido es requerido")]
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage="El campo tipo es requerido")]
        public int TipoID { get; set; }
        public TipoAlerta Tipo { get; set; }
    }
}