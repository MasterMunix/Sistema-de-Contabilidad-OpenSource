using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_contabilidad_Open_Source.Models.ViewModels
{
    public class cuentasContablesViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Tipo de cuenta")]
        public int tipoCuenta { get; set; }
        //
        
        public List <tipoCuentas> lst1 { get; set; }
        //
        //
        
        public List<cuentasContables> lstCuentaMayor { get; set; }
        //
        [Required]
        [Display(Name ="¿Permite Transacciones?")]
        public bool permiteTrans { get; set; }
        [Required]
        [MaxLength(1)] 
        [Range(1,3)]
        [Display(Name = "Nivel")]
        public string nivel { get; set; }
        [Required]
        [Display(Name = "Cuenta Mayor")]
        [Range(0, Int32.MaxValue)]
        public int cuentaMayor { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name ="Balance")]
        public double balance { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}