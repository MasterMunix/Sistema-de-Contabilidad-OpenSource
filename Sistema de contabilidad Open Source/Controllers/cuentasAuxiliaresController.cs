using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_de_contabilidad_Open_Source.Models;
using Sistema_de_contabilidad_Open_Source.Models.ViewModels;

namespace Sistema_de_contabilidad_Open_Source.Controllers
{
    public class cuentasAuxiliaresController : Controller
    {
        // GET: cuentasAuxiliares
        public ActionResult Index()
        {

            List<ListcuentasAuxiliaresViewModel> lst;
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {

                lst = (from d in db.cuentasAuxiliares
                       select new ListcuentasAuxiliaresViewModel
                       {
                           ID = d.cuentasAuxiliaresID,
                           descripcion = d.descripcion,
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
        public ActionResult Nuevo(cuentasAuxiliaresViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {

                        var ocuentasAuxiliares = new cuentasAuxiliares();

                        ocuentasAuxiliares.descripcion = model.descripcion;
                        ocuentasAuxiliares.estado = model.estado;

                        db.cuentasAuxiliares.Add(ocuentasAuxiliares);
                        db.SaveChanges();
                    };

                    return Redirect("/cuentasAuxiliares");

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
            cuentasAuxiliaresViewModel model = new cuentasAuxiliaresViewModel();
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                var ocuentasAuxiliares = db.cuentasAuxiliares.Find(ID);
                model.descripcion = ocuentasAuxiliares.descripcion;
                model.estado = ocuentasAuxiliares.estado;
                model.ID = ocuentasAuxiliares.cuentasAuxiliaresID;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(cuentasAuxiliaresViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {

                        var ocuentasAuxiliares = db.cuentasAuxiliares.Find(model.ID);

                        ocuentasAuxiliares.descripcion = model.descripcion;
                        ocuentasAuxiliares.estado = model.estado;

                        db.Entry(ocuentasAuxiliares).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    };

                    return Redirect("/cuentasAuxiliares");

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
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                var ocuentasAuxiliares = db.cuentasAuxiliares.Find(ID);
                db.cuentasAuxiliares.Remove(ocuentasAuxiliares);
                db.SaveChanges();
            }
            return Redirect("/cuentasAuxiliares/");
        }
    }
}