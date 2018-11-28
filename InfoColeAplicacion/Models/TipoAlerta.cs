using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    public class TipoAlerta
    {
        [Key]
        public int TipoID { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}