using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using Sistema_de_contabilidad_Open_Source.Models;
using Sistema_de_contabilidad_Open_Source.Models.ViewModels;

namespace Sistema_de_contabilidad_Open_Source.Controllers
{
    public class tipoCuentasController : Controller
    {
        // GET: tipoCuentas
        public ActionResult Index()
        {
            List<ListtipoCuentasVIewModel> lst;
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
               
                 lst = (from d in db.tipoCuentas
                          select new ListtipoCuentasVIewModel
                          {
                              ID = d.tipoCuentasID,
                              descripcion = d.Descripcion,
                              origen = d.origen,
                              estado = d.estado
                          }).ToList();
            }
            return View(lst);
        }
        //Nuevo
        public ActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(tipoCuentaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {

                        var otipoCuenta = new tipoCuentas();

                        otipoCuenta.Descripcion = model.descripcion;
                        otipoCuenta.origen = model.origen;
                        otipoCuenta.estado = model.estado;

                        db.tipoCuentas.Add(otipoCuenta);
                        db.SaveChanges();
                    };

                    return Redirect("/tipoCuentas");

                }
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
            tipoCuentaViewModel model = new tipoCuentaViewModel();
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                var otipoCuentas = db.tipoCuentas.Find(ID);
                model.descripcion = otipoCuentas.Descripcion;
                model.origen = otipoCuentas.origen;
                model.estado = otipoCuentas.estado;
                model.ID = otipoCuentas.tipoCuentasID;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(tipoCuentaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {

                        var otipoCuentas = db.tipoCuentas.Find(model.ID);

                        otipoCuentas.Descripcion = model.descripcion;
                        otipoCuentas.origen = model.origen;
                        otipoCuentas.estado = model.estado;

                        db.Entry(otipoCuentas).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    };

                    return Redirect("/tipoCuentas");

                }
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
             using( Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                {
                    var otipoCuentas = db.tipoCuentas.Find(ID);
                    db.tipoCuentas.Remove(otipoCuentas);
                    db.SaveChanges();
                }
            return Redirect("/tipoCuentas/");
        }
          
            
        }
       
    }


    
