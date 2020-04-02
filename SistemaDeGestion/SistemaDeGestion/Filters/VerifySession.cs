using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaDeGestion.Controllers;
using SistemaDeGestion.Models;

namespace SistemaDeGestion.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = HttpContext.Current.Session["User"];

            if(oUser == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}