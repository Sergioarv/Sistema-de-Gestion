using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaDeGestion.Models;

namespace SistemaDeGestion.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string pass)
        {
            try
            {
                using (DataBasesSGCEntities db = new DataBasesSGCEntities())
                {
                    var list = from d in db.Admin
                               where d.email == user && d.password == pass
                               select d;

                    if (list.Count() > 0)
                    {
                        Session["User"] = list.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }

                
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }
    }
}