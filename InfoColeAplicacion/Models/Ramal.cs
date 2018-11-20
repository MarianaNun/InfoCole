using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class Ramal
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public virtual Linea Linea { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
    }
}