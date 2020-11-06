using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_de_contabilidad_Open_Source.Models.ViewModels
{
    public class asientoContableViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name ="Identificador Auxiliar")]
        public int identificadorAuxiliar { get; set; }
        //Traer los datos desde la tabla cuentasAuxiliares mediante un List
        public List<cuentasAuxiliares> lstCuentasAuxiliares { get; set; }
        //
        [Required]
        [Display(Name ="Cuenta asociada")]
        public int cuenta { get; set; }
        //Traer los datos desde la tabla cuentasContables mediante un List
        public List<cuentasContables> lstCuentasContables { get; set; }
        //
        [Required]
        [StringLength(2)]
        [Display(Name = "Tipo de movimiento")]
        public string tipoMovimiento { get; set; }
        [Required]
        [Display(Name ="Fecha")]
        public DateTime fecha { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name = "Monto")]
        public double monto { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        [Required]
        [Display(Name ="Moneda a cambiar")]
        public int tipoMoneda { get; set; }
        //Traer los datos desde la tabla cuentasAuxiliares mediante un List
        public List<tipoMonedas> lstTipoMoneda { get; set; }
        //
    }
}