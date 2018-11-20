using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfoColeAplicacion.Models
{
    [NotMapped]
    public class Paginador<T> where T : class
    {
        [NotMapped]
        public int PaginaActual { get; set; }
        [NotMapped]
        public int RegistrosPorPagina { get; set; }
        [NotMapped]
        public int TotalRegistros { get; set; }
        [NotMapped]
        public int TotalPaginas { get; set; }
        [NotMapped]
        public IEnumerable<T> Resultado { get; set; }
    }
}