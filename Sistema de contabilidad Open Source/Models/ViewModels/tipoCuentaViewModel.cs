using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_contabilidad_Open_Source.Models.ViewModels
{
    public class tipoCuentaViewModel
    {   
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Descripción")]
        public string descripcion { get; set; }
        [Required]
        [StringLength(2)]
        [Display(Name = "Origen de la transaccion")]
        public string origen { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}