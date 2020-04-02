using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaDeGestion.Models;

namespace SistemaDeGestion.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int Id)
        {
            if (Id == -1)
            {
                return View();
            }

            DataBasesSGCEntities db = new DataBasesSGCEntities();
            ViewBag.destino = db.Flyer.Find(Id).name;
            return View();
        }

        [HttpPost]
        public ActionResult Create(RequestModel model)
        {

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            return View();
        }
    }
}