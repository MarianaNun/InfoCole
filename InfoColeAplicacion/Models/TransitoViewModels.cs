using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using InfoColeAplicacion.Models;

namespace InfoColeAplicacion.Models
{
    public class TransitoViewModels
    {
        public string contenido{ get; set; }
        public int tipo{ get; set; }
        public string linea { get; set; }

    }
}