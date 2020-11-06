using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_contabilidad_Open_Source.Models.ViewModels
{
    public class ListtipoCuentasVIewModel
    {
        public int ID { get; set; }
        public string descripcion { get; set; }

        public string origen { get; set; }

        public bool estado { get; set; }
    }
}