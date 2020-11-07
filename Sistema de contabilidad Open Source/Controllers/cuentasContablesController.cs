using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_de_contabilidad_Open_Source.Models;
using Sistema_de_contabilidad_Open_Source.Models.ViewModels;


namespace Sistema_de_contabilidad_Open_Source.Controllers
{
    public class cuentasContablesController : Controller
    {
        // GET: cuentasContables
        public ActionResult Index()
        {
            List<ListcuentasContablesViewModel> lst;
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                
                lst = (from d in db.cuentasContables
                       select new ListcuentasContablesViewModel
                       {
                           ID = d.cuentasContablesID,
                           descripcion = d.Descripcion,
                           tipoCuenta = d.tipoCuenta,
                           permiteTrans = d.permiteTrans,
                           nivel = d.nivel,
                           cuentaMayor = d.cuentaMayor,
                           balance = d.balance,
                           estado = d.estado,
                           //
                           lst1 = db.tipoCuentas.ToList<tipoCuentas>(),
                           lstCuentaMayor = db.cuentasContables.ToList<cuentasContables>()
                           //
            }).ToList();
            }

            return View(lst);
        }
        
      

        //Nuevo
        public ActionResult Nuevo()
        {

            cuentasContablesViewModel model = new cuentasContablesViewModel();
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                model.lst1 = db.tipoCuentas.Where(s => s.estado == true).ToList<tipoCuentas>();
                model.lstCuentaMayor = db.cuentasContables.Where(s => s.estado == true).ToList<cuentasContables>();
            }

            return View(model);

        }


        [HttpPost]
        public ActionResult Nuevo(cuentasContablesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //saque este var de abajo, es decir, estaba dentro del using
                    var ocuentasContables = new cuentasContables();
                    //
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {
                        
                        ocuentasContables.Descripcion = model.descripcion;
                        ocuentasContables.tipoCuenta = model.tipoCuenta;
                        ocuentasContables.permiteTrans = model.permiteTrans;
                        if (ocuentasContables.Descripcion == "Activos Fijos")
                        {
                            ocuentasContables.cuentaMayor = 0;
                        }
                        else
                        {
                            ocuentasContables.cuentaMayor = model.cuentaMayor;
                        }
                        ocuentasContables.nivel = model.nivel;
                        ocuentasContables.balance = model.balance;
                        ocuentasContables.estado = model.estado;
                        
                        //Guardar
                        db.cuentasContables.Add(ocuentasContables);
                        db.SaveChanges();
                    };
                    
                    return Redirect("/cuentasContables");

                }
                //Esto carga nuevamente los dropdownlist para que no aparezca un error de nulo
                using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                {
                    model.lst1 = db.tipoCuentas.Where(s => s.estado == true).ToList<tipoCuentas>();
                    model.lstCuentaMayor = db.cuentasContables.Where(s => s.estado == true).ToList<cuentasContables>();
                }
                //


                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Editar

        public ActionResult Editar(int ID)
        {
            cuentasContablesViewModel model = new cuentasContablesViewModel();
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                var ocuentasContables = db.cuentasContables.Find(ID);
                model.descripcion = ocuentasContables.Descripcion;
                model.tipoCuenta = ocuentasContables.tipoCuenta;
                model.permiteTrans = ocuentasContables.permiteTrans;
                model.nivel = ocuentasContables.nivel;
                model.cuentaMayor = ocuentasContables.cuentaMayor;
                model.balance = ocuentasContables.balance;
                model.estado = ocuentasContables.estado;
                model.ID = ocuentasContables.cuentasContablesID;
                //Esto carga nuevamente los dropdownlist para que no aparezca un error de nulo
                model.lst1 = db.tipoCuentas.Where(s => s.estado == true).ToList<tipoCuentas>();
                model.lstCuentaMayor = db.cuentasContables.Where(s => s.estado == true).ToList<cuentasContables>();
                //
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(cuentasContablesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {

                        var ocuentasContables = db.cuentasContables.Find(model.ID);

                        ocuentasContables.Descripcion = model.descripcion;
                        ocuentasContables.tipoCuenta = model.tipoCuenta;
                        ocuentasContables.permiteTrans = model.permiteTrans;
                        ocuentasContables.nivel = model.nivel;
                        ocuentasContables.cuentaMayor = model.cuentaMayor;
                        ocuentasContables.balance = model.balance;
                        ocuentasContables.estado = model.estado;
                       

                        db.Entry(ocuentasContables).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    };
                   
                    return Redirect("/cuentasContables");

                }
                //Esto carga nuevamente los dropdownlist para que no aparezca un error de nulo
                using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                {
                    model.lst1 = db.tipoCuentas.Where(s => s.estado == true).ToList<tipoCuentas>();
                    model.lstCuentaMayor = db.cuentasContables.Where(s => s.estado == true).ToList<cuentasContables>();
                }
                //
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Eliminar
        public ActionResult Eliminar(int ID)
        {
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                var ocuentasContables = db.cuentasContables.Find(ID);
                db.cuentasContables.Remove(ocuentasContables);
                db.SaveChanges();
            }
            return Redirect("/cuentasContables/");
        }
    }
}