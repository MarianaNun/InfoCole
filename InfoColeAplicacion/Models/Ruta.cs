using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class Ruta
    {
        [Key]
        public int RutaId { get; set; }

        public virtual List<PuntoRuta> Puntos { get; set; }

        
        public int ID { get; set; }
        public Linea Linea { get; set; }
    }
}