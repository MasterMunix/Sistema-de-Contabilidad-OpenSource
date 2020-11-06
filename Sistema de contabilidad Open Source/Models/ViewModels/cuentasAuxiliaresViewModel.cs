using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_de_contabilidad_Open_Source.Models.ViewModels
{
    public class cuentasAuxiliaresViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}