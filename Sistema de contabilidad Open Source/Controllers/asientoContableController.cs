using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_de_contabilidad_Open_Source.Models;
using Sistema_de_contabilidad_Open_Source.Models.ViewModels;

namespace Sistema_de_contabilidad_Open_Source.Controllers
{
    public class asientoContableController : Controller
    {
        // GET: asientoContable
        public ActionResult Index()
        {

            List<ListasientoContableViewModel> lst;
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {

                lst = (from d in db.asientoContable
                       select new ListasientoContableViewModel
                       {
                           ID = d.asientoContableID,
                           descripcion = d.descripcion,
                           identificadorAuxiliar = d.identificadorAuxiliar,
                           cuenta = d.cuenta,
                           tipoMovimiento = d.tipoMovimiento,
                           fecha = d.fecha,
                           monto = d.monto,
                           estado = d.estado,
                           tipoMoneda = d.tipoMoneda,
                           //
                           lstCuentasAuxiliares = db.cuentasAuxiliares.ToList<cuentasAuxiliares>(),
                           lstCuentasContables = db.cuentasContables.ToList<cuentasContables>(),
                           lstTipoMoneda = db.tipoMonedas.ToList<tipoMonedas>()
                           //
                       }).ToList();
            }

            return View(lst);
        }
        //Nuevo
        public ActionResult Nuevo()
        {

            asientoContableViewModel model = new asientoContableViewModel();
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                model.lstCuentasAuxiliares = db.cuentasAuxiliares.ToList<cuentasAuxiliares>();
                model.lstCuentasContables = db.cuentasContables.ToList<cuentasContables>();
                model.lstTipoMoneda = db.tipoMonedas.ToList<tipoMonedas>();
            }

            return View(model);

        }


        [HttpPost]
        public ActionResult Nuevo(asientoContableViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //saque este var de abajo, es decir, estaba dentro del using
                    var oasientoContable = new asientoContable();
                    
                    //
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {
                        var otipoMoneda = new tipoMonedas();
                        oasientoContable.descripcion = model.descripcion;
                        oasientoContable.identificadorAuxiliar = model.identificadorAuxiliar;
                        oasientoContable.cuenta = model.cuenta;
                        oasientoContable.tipoMovimiento = model.tipoMovimiento;
                        oasientoContable.fecha = DateTime.Now.GetDateTimeFormats("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss");
                        oasientoContable.monto = model.monto;
                        oasientoContable.estado = model.estado;
                        oasientoContable.tipoMoneda = model.tipoMoneda;
                        

                        //Guardar
                        db.asientoContable.Add(oasientoContable);
                        db.SaveChanges();
                    };

                    return Redirect("/asientoContable/");

                }
                //Esto carga nuevamente los dropdownlist para que no aparezca un error de nulo
                using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                {
                    model.lstCuentasAuxiliares = db.cuentasAuxiliares.ToList<cuentasAuxiliares>();
                    model.lstCuentasContables = db.cuentasContables.ToList<cuentasContables>();
                    model.lstTipoMoneda = db.tipoMonedas.ToList<tipoMonedas>();
                }
                //


                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.InnerException.Message);

            }
        }


        //Editar


    }
}