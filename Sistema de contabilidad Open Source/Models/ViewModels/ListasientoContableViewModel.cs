using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_de_contabilidad_Open_Source.Models.ViewModels
{
    public class ListasientoContableViewModel
    {
        public int ID { get; set; }
        public string descripcion { get; set; }
        public int identificadorAuxiliar { get; set; }
        //
        [NotMapped]
        public List<cuentasAuxiliares> lstCuentasAuxiliares { get; set; }
        //
        public int cuenta { get; set; }
        //
        [NotMapped]
        public List<cuentasContables> lstCuentasContables { get; set; }
        //
        
        public string tipoMovimiento { get; set; }
        public DateTime? fecha { get; set; }
        public double monto { get; set; }
        public bool estado { get; set; }
        public int tipoMoneda { get; set; }
        //
        [NotMapped]
        public List<tipoMonedas> lstTipoMoneda { get; set; }

        //busqueda
        [NotMapped]
        public IQueryable busquedaAsientosContables { get; set; }
        //

    }
}