using SistemaDeGestion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeGestion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<FlyerModel> lst = null;

            using (DataBasesSGCEntities db = new DataBasesSGCEntities())
            {
                lst = (from d in db.Flyer
                       select new FlyerModel
                       {
                           Id = d.id,
                           Name = d.name,
                           Description = d.description,
                           Imagen = d.imagen
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult FlyerDetails(int Id)
        {
            FlyerModel model = new FlyerModel();

            using (DataBasesSGCEntities db = new DataBasesSGCEntities())
            {
                var oFlyer = db.Flyer.Find(Id);

                model.Id = oFlyer.id;
                model.Imagen = oFlyer.imagen;
                model.Description = oFlyer.description;
                model.Name = oFlyer.name;
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}