using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace InfoColeAplicacion.Models
{
    public class TransitoViewModels
    {
        [Required]
        [Display(Name = "Descrpcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public string SelectedTipo{ get; set; }
        public IEnumerable<SelectListItem> Tipo { get; set; }
    }
}