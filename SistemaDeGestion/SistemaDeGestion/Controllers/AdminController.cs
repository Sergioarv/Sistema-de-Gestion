using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaDeGestion.Models;

namespace SistemaDeGestion.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            List<AdminModel> lst = null;

            using (DataBasesSGCEntities db = new DataBasesSGCEntities())
            {
                lst = (from d in db.Admin
                       where d.email == "lacasadelturismo@gmail.com"
                       orderby d.email
                       select new AdminModel
                       {
                           Id = d.id,
                           Email = d.email,
                           Password = d.password
                       }).ToList();
            }

            return View(lst);
        }
    }
}