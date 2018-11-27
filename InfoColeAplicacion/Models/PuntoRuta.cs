using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class PuntoRuta
    {
        [Key]
        public int PuntoMapaId { get; set; }

        public int RutaId { get; set; }


        public string Long { get; set; }

        public string Lat { get; set; }
    }
}