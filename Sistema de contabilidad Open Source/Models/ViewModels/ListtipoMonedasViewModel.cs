using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_contabilidad_Open_Source.Models.ViewModels
{
    public class ListtipoMonedasViewModel
    {
        public int ID { get; set; }
        public string descripcion { get; set; }

        public double tasaCambiaria { get; set; }

        public bool estado { get; set; }
    }
}