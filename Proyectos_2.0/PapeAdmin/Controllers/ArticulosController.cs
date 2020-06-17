using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PapeAdmin.DAL;
using PapeAdmin.Models;

namespace PapeAdmin.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: Articulos
        //Seccion Tipo de Productos
        TprodDAL oTprodDAL;
        public ActionResult TipodeProducto()
        {
            ViewData["ProdActivo"] = "active";
            ViewData["TProd"] = "active";
            return View();
        }

        [HttpPost]
        public ActionResult tablaTproducto()
        {
            oTprodDAL = new TprodDAL();
            List<TprodModel> listTprod = null;
            listTprod = oTprodDAL.ListaTprod();
            return Json(new { listTprod }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult nuevoTprod(string tprod)
        {
            if (ModelState.IsValid)
            {
                oTprodDAL = new TprodDAL();
                int respuestaDelServidorSQL = oTprodDAL.Agregar(tprod);
                if (respuestaDelServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Se guardo correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al guardar en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult modificarTprod(string tprod, int id)
        {
            if (ModelState.IsValid)
            {
                oTprodDAL = new TprodDAL();
                int respuestaDelServidorSQL = oTprodDAL.Editar(tprod, id);
                if (respuestaDelServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Se actualizo correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error actualizando la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult seleccionarTprod(int id)
        {
            if (ModelState.IsValid)
            {
                oTprodDAL = new TprodDAL();
                List<TprodModel> listTprod = null;
                listTprod = oTprodDAL.seleccionar(id);
                return Json(new { listTprod }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { Value = false, Message = "El código proporcionado es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult eliminarTprod(int id)
        {
            if (ModelState.IsValid)
            {
                oTprodDAL = new TprodDAL();
                int respuestaServidorSQL = oTprodDAL.Eliminar(id);
                if (respuestaServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Se ha eliminado correctamente de la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al eliminar de la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(new { Value = false, Message = "El código proporcionado es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Fin SeccionTipodeProducto



        //Seccion Marcas
        MarcasDAL oMarcasDAL;
        public ActionResult Marca()
        {
            ViewData["ProdActivo"] = "active";
            ViewData["Marca"] = "active";
            return View();
        }
        [HttpPost]
        public ActionResult tablaMarcas()
        {
            oMarcasDAL = new MarcasDAL();
            List<MarcasModel> listMarcas = null;
            listMarcas = oMarcasDAL.ListaMarcas();
            return Json(new { listMarcas }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SeleccionarMarca(int id)
        {
            if (ModelState.IsValid)
            {
                oMarcasDAL = new MarcasDAL();
                List<MarcasModel> listMarcas = null;
                listMarcas = oMarcasDAL.MarcaSeleccionada(id);
                return Json(new { listMarcas }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { Value = false, Message = "El código proporcionado es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult EstatusMarca(int id, string val)
        {
            if (ModelState.IsValid)
            {
                int sta = 0;
                string letra;
                if (val == "1")
                {
                    sta = 0;
                    letra = "desactivado";
                }
                else
                {
                    sta = 1;
                    letra = "activado";
                }
                oMarcasDAL = new MarcasDAL();
                int respuestaDelServidorSQL = oMarcasDAL.cambiarEstatus(id, sta);
                if (respuestaDelServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Estatus " + letra + " correctamente" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al actualizar estatus" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult NuevoMarcas(HttpPostedFileBase logo, HttpPostedFileBase banner,string nombre,string frase,string descripcion)
        {
            if (ModelState.IsValid)
            {
                string rutaParaSubir = Server.MapPath("~\\images\\Marcas\\");
                int respuestaDeLogo = subirArchivo(logo, rutaParaSubir);
                string nombreDeLogo = logo.FileName.ToString();
                if (respuestaDeLogo == 1)
                {
                    string rutaParaSubirBanner = Server.MapPath("~\\images\\Banners\\");
                    int respuestaDeBanner = subirArchivo(banner, rutaParaSubirBanner);
                    string nombreDeBanner = logo.FileName.ToString();
                    if (respuestaDeBanner == 1)
                    {
                        oMarcasDAL = new MarcasDAL();
                        int respuestaDelServidorSQL = oMarcasDAL.Agregar(nombre, descripcion, frase, nombreDeLogo, nombreDeBanner);
                        if (respuestaDelServidorSQL == 1)
                        {
                            return Json(new { Value = true, Message = "Se ha guardado correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { Value = false, Message = "Ocurrio un error al guardar en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { Value = false, Message = "Ocurrio un error al guardar el Logo en el Servidor" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al guardar el Logo en el Servidor" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Fin Seccion Marcas
       

        public ActionResult Producto()
        {
            ViewData["ProdActivo"] = "active";
            ViewData["Producto"] = "active";
            return View();
        }

        private int subirArchivo(HttpPostedFileBase file, string rutaParaGuardar)
        {
            try
            {
                file.SaveAs(rutaParaGuardar + Path.GetFileName(file.FileName));
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}