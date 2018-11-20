using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace InfoColeAplicacion.Models
{
    public class Comentario
    {
        public int ID { get; set; }
        [Required]
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public Boolean Tipo { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual Linea Linea { get; set; }
        public virtual Ramal Ramal { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

}