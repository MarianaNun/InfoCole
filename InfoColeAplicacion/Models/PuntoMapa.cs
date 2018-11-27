using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class PuntoMapa
    {
        [Key]
        public int PuntoMapaId { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [MaxLength(100)]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Descripcion { get; set; }

        [Required]
        public string Long { get; set; }

        [Required]
        public string Lat { get; set; }

        public int TipoPuntoMapaId { get; set; }
        public TipoPuntoMapa Tipo { get; set; }
    }
}