using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PapeAdmin.DAL;

namespace PapeAdmin.Controllers
{
    public class SistemaController : Controller
    {
        // GET: Sistema

        CatalogosDAL oCatalogosDAL;
        public ActionResult Inicio()
        {
            ViewData["InicioActivo"] = "active";
            return View();
        }

        [ChildActionOnly]
        public ActionResult ListaCatalogo()
        {
            oCatalogosDAL = new CatalogosDAL();
            return PartialView(oCatalogosDAL.MostrarParaMaster());

        }


    }
}