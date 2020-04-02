using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaDeGestion.Models;
using SistemaDeGestion.Classes;

namespace SistemaDeGestion.Controllers
{
    public class FlyerController : Controller
    {
        // GET: Flyer
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ImageFlyer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Verificar si hay una imagen https://www.youtube.com/watch?v=XtjoCuE_J48

            var pic = string.Empty;
            var folder = "~/Content/img";

            if(model.ImageFile == null)
            {
                return View(model);
            }

            pic = FilesHelper.UploadPhoto(model.ImageFile, folder);
            pic = string.Format("{0}/{1}", folder, pic);

            using (var db = new DataBasesSGCEntities())
            {
                Flyer oFlyer = new Flyer();
                oFlyer.description = model.Description;
                oFlyer.name = model.Name;
                oFlyer.imagen = model.Imagen;
                oFlyer.imagen = pic;

                db.Flyer.Add(oFlyer);
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Flyer/Index"));
        }

        public ActionResult Edit(int Id)
        {
            EditImageFlyer model = new EditImageFlyer();
            
            using (var db = new DataBasesSGCEntities())
            {
                var oFlyer = db.Flyer.Find(Id);
                model.Description = oFlyer.description;
                model.Name = oFlyer.name;
                model.Imagen = oFlyer.imagen;
                model.Id = oFlyer.id;
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditImageFlyer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            
            var pic = string.Empty;
            var folder = "~/Content/img";

            if (model.ImageFile != null)
            {
                pic = FilesHelper.UploadPhoto(model.ImageFile, folder);
                pic = string.Format("{0}/{1}", folder, pic);

                using (var db = new DataBasesSGCEntities())
                {
                    var oFlyer = db.Flyer.Find(model.Id);
                    oFlyer.description = model.Description;
                    oFlyer.name = model.Name;
                    oFlyer.imagen = model.Imagen;
                    oFlyer.imagen = pic;

                    db.Entry(oFlyer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new DataBasesSGCEntities())
                {
                    var oFlyer = db.Flyer.Find(model.Id);
                    oFlyer.description = model.Description;
                    oFlyer.name = model.Name;

                    db.Entry(oFlyer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return Redirect(Url.Content("~/Flyer/Index"));
        }

        public ActionResult Delete(int Id)
        {
            DeleteFlyerModel model = new DeleteFlyerModel();

            using (var db = new DataBasesSGCEntities())
            {
                var oFlyer = db.Flyer.Find(Id);

                model.Description = oFlyer.description;
                model.Imagen = oFlyer.imagen;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteFlyerModel model)
        {
            using (var db = new DataBasesSGCEntities())
            {
                Flyer oFlyer = db.Flyer.Find(model.Id);
                db.Flyer.Remove(oFlyer);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Flyer/Index"));
        }

    }
}