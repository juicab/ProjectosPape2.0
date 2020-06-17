using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapeAdmin.Controllers
{
    public class UbicacionController : Controller
    {
        // GET: Ubicacion
        public ActionResult Estado()
        {
            ViewData["UbiActivo"] = "active";
            ViewData["Estado"] = "active";
            return View();
        }

        public ActionResult Municipio()
        {
            ViewData["UbiActivo"] = "active";
            ViewData["Municipio"] = "active";
            return View();
        }

        public ActionResult Direcciones()
        {
            ViewData["UbiActivo"] = "active";
            ViewData["Direcciones"] = "active";
            return View();
        }



    }
}