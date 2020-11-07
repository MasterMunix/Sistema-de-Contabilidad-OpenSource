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
        public ActionResult Index(string searchString)
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

                model.lstCuentasAuxiliares = db.cuentasAuxiliares.Where(s => s.estado == true).ToList<cuentasAuxiliares>();
                model.lstCuentasContables = db.cuentasContables.Where(s => s.estado == true && s.permiteTrans == true).ToList<cuentasContables>();
                model.lstTipoMoneda = db.tipoMonedas.Where(s => s.estado == true).ToList<tipoMonedas>();

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
                        //
                        model.lstTipoMoneda = db.tipoMonedas.ToList<tipoMonedas>();
                        //
                        var otipoMoneda = new tipoMonedas();
                        oasientoContable.descripcion = model.descripcion;
                        oasientoContable.identificadorAuxiliar = model.identificadorAuxiliar;
                        oasientoContable.cuenta = model.cuenta;
                        oasientoContable.tipoMovimiento = model.tipoMovimiento;
                        oasientoContable.fecha = DateTime.Now;
                        foreach (var valor in model.lstTipoMoneda)
                        {
                            if (model.tipoMoneda == valor.tipoMonedasID)
                            {
                                oasientoContable.monto = valor.tasaCambiaria * model.monto;
                            }
                        }
                       
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
                    model.lstCuentasAuxiliares = db.cuentasAuxiliares.Where(s => s.estado == true).ToList<cuentasAuxiliares>();
                    model.lstCuentasContables = db.cuentasContables.Where(s => s.estado == true && s.permiteTrans == true).ToList<cuentasContables>();
                    model.lstTipoMoneda = db.tipoMonedas.Where(s => s.estado == true).ToList<tipoMonedas>();

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

        public ActionResult Editar(int ID)
        {
            asientoContableViewModel model = new asientoContableViewModel();
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                model.lstTipoMoneda = db.tipoMonedas.ToList<tipoMonedas>();
                var oasientoContable = db.asientoContable.Find(ID);
                model.descripcion = oasientoContable.descripcion;
                model.identificadorAuxiliar = oasientoContable.identificadorAuxiliar;
                model.cuenta = oasientoContable.cuenta;
                model.tipoMovimiento = oasientoContable.tipoMovimiento;
                model.fecha = oasientoContable.fecha;
                model.estado = oasientoContable.estado;
                model.tipoMoneda = oasientoContable.tipoMoneda;
                //Para que aparezca los datos originales
                foreach (var valor in model.lstTipoMoneda)
                {
                    if (model.tipoMoneda == valor.tipoMonedasID)
                    {
                        model.monto = oasientoContable.monto / valor.tasaCambiaria;
                    }
                }
                model.ID = oasientoContable.asientoContableID;
                //Esto carga nuevamente los dropdownlist para que no aparezca un error de nulo

                model.lstCuentasAuxiliares = db.cuentasAuxiliares.Where(s => s.estado == true).ToList<cuentasAuxiliares>();
                model.lstCuentasContables = db.cuentasContables.Where(s => s.estado == true && s.permiteTrans == true).ToList<cuentasContables>();
                model.lstTipoMoneda = db.tipoMonedas.Where(s => s.estado == true).ToList<tipoMonedas>();
                //
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(asientoContableViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {
                        var oasientoContable = db.asientoContable.Find(model.ID);
                        //
                        model.lstTipoMoneda = db.tipoMonedas.ToList<tipoMonedas>();
                        //
                        var otipoMoneda = new tipoMonedas();

                        oasientoContable.descripcion = model.descripcion;
                        oasientoContable.identificadorAuxiliar = model.identificadorAuxiliar;
                        oasientoContable.cuenta = model.cuenta;
                        oasientoContable.tipoMovimiento = model.tipoMovimiento;
                        oasientoContable.fecha = DateTime.Now;
                        foreach (var valor in model.lstTipoMoneda)
                        {
                            if (model.tipoMoneda == valor.tipoMonedasID)
                            {
                                oasientoContable.monto = valor.tasaCambiaria * model.monto;
                            }
                        }
                        
                        oasientoContable.estado = model.estado;
                        oasientoContable.tipoMoneda = model.tipoMoneda;
                        

                        db.Entry(oasientoContable).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    };

                    return Redirect("/asientoContable");

                }
                //Esto carga nuevamente los dropdownlist para que no aparezca un error de nulo
                using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                {
                    model.lstCuentasAuxiliares = db.cuentasAuxiliares.Where(s => s.estado == true).ToList<cuentasAuxiliares>();
                    model.lstCuentasContables = db.cuentasContables.Where(s => s.estado == true && s.permiteTrans == true).ToList<cuentasContables>();
                    model.lstTipoMoneda = db.tipoMonedas.Where(s => s.estado == true).ToList<tipoMonedas>();
                }
                //
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        //Eliminar
        //Eliminar
        public ActionResult Eliminar(int ID)
        {
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                var oasientoContable = db.asientoContable.Find(ID);
                db.asientoContable.Remove(oasientoContable);
                db.SaveChanges();
            }
            return Redirect("/asientoContable/");
        }

    }
}