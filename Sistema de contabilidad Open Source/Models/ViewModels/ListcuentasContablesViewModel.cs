using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_contabilidad_Open_Source.Models.ViewModels
{
    public class ListcuentasContablesViewModel
    {
        public int ID { get; set; }
        public string descripcion { get; set; }
        public int tipoCuenta { get; set; }
        //
        [NotMapped]
        public List<tipoCuentas> lst1 { get; set; }
        //
        //
        [NotMapped]
        public List<cuentasContables> lstCuentaMayor { get; set; }
        //
        public bool permiteTrans { get; set; }
        public string nivel { get; set; }
        public int cuentaMayor { get; set; }
        public double balance { get; set; }
        public bool estado { get; set; }
      
    }
}