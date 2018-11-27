using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class TipoPuntoMapa
    {
        public int TipoPuntoMapaId { get; set; }

        [Required(ErrorMessage ="Debe campo {0} es obligatorio")]
        public string Nombre { get; set; }
    }
}