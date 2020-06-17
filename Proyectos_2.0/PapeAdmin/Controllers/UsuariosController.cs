using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapeAdmin.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Empleados()
        {
            @ViewData["UserActivo"] = "active";
            @ViewData["Empleados"] = "active";
            return View();
        } 

        public ActionResult Clientes()
        {
            @ViewData["UserActivo"] = "active";
            @ViewData["Clientes"] = "active";
            return View();
        }

    }
}