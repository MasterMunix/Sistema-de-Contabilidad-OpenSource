using System.Web;
using System.Web.Mvc;

namespace Sistema_de_contabilidad_Open_Source
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
