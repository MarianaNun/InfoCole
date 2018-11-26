using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.ViewModels
{
    public class NoticiaViewModel
    {
        public int NoticiaId { get; set; }

        public string Titulo { get; set; }

        public DateTime FechaPublicacion { get; set; }
    }
}