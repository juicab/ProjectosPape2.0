using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Papeleria_Merida_2._0.DAL;
using Papeleria_Merida_2._0.Models;
using System.Data;
using System.Web.Script.Serialization;
using System.Text;

namespace Papeleria_Merida_2._0.Controllers
{
	public class PapeleriaController : Controller
	{
		// GET: Papeleria
		public ActionResult Inicio()
		{
			return View();
		}

		PrincipalDAL oPrincipalDAL;
		[ChildActionOnly]
		public ActionResult Principal()
		{
			return PartialView();
		}
		[HttpPost]
		public ActionResult tablaPrincipal()
		{
			oPrincipalDAL = new PrincipalDAL();
			List<PrincipalModel> listPrin = null;
			listPrin = oPrincipalDAL.ListaPrincipal();
			return Json(new { listPrin }, JsonRequestBehavior.AllowGet);
		}





		[ChildActionOnly]
		public ActionResult Marcas()
		{
			return PartialView();
		}

		[ChildActionOnly]
		public ActionResult Compras()
		{
			return PartialView();
		}

		[ChildActionOnly]
		public ActionResult Nosotros()
		{
			return PartialView();
		}

		[ChildActionOnly]
		public ActionResult Catalogos()
		{
			return PartialView();
		}

		[ChildActionOnly]
		public ActionResult Reparaciones()
		{
			return PartialView();
		}

		[ChildActionOnly]
		public ActionResult Contacto()
		{
			return PartialView();
		}
	}
}