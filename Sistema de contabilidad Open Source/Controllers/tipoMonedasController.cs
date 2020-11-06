using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_de_contabilidad_Open_Source.Models;
using Sistema_de_contabilidad_Open_Source.Models.ViewModels;

namespace Sistema_de_contabilidad_Open_Source.Controllers
{
    public class tipoMonedasController : Controller
    {
        // GET: tipoMonedas
        public ActionResult Index()
        {
            List<ListtipoMonedasViewModel> lst;
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {

                lst = (from d in db.tipoMonedas
                       select new ListtipoMonedasViewModel
                       {
                           ID = d.tipoMonedasID,
                           descripcion = d.Descripcion,
                           tasaCambiaria = d.tasaCambiaria,
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
        public ActionResult Nuevo(tipoMonedasViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {

                        var otipoMonedas = new tipoMonedas();

                        otipoMonedas.Descripcion = model.descripcion;
                        otipoMonedas.tasaCambiaria = model.tasaCambiaria;
                        otipoMonedas.estado = model.estado;

                        db.tipoMonedas.Add(otipoMonedas);
                        db.SaveChanges();
                    };

                    return Redirect("/tipoMonedas");

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
            tipoMonedasViewModel model = new tipoMonedasViewModel();
            using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
            {
                var otipoMonedas = db.tipoMonedas.Find(ID);
                model.descripcion = otipoMonedas.Descripcion;
                model.tasaCambiaria = otipoMonedas.tasaCambiaria;
                model.estado = otipoMonedas.estado;
                model.ID = otipoMonedas.tipoMonedasID;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(tipoMonedasViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Segundo_Parcial_Integracion_con_Open_SourceEntities db = new Segundo_Parcial_Integracion_con_Open_SourceEntities())
                    {

                        var otipoMonedas = db.tipoMonedas.Find(model.ID);

                        otipoMonedas.Descripcion = model.descripcion;
                        otipoMonedas.tasaCambiaria = model.tasaCambiaria;
                        otipoMonedas.estado = model.estado;

                        db.Entry(otipoMonedas).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    };

                    return Redirect("/tipoMonedas");

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
                var otipoMonedas = db.tipoMonedas.Find(ID);
                db.tipoMonedas.Remove(otipoMonedas);
                db.SaveChanges();
            }
            return Redirect("/tipoMonedas/");
        }
    }
}