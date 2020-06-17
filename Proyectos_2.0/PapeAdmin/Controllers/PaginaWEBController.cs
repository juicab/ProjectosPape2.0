using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;
using PapeAdmin.DAL;
using System.Data;
using System.Web.Script.Serialization;
using System.Text;
using PapeAdmin.Models;

namespace PapeAdmin.Controllers
{
    public class PaginaWEBController : Controller
    {


        // GET: PaginaWEB

        //Inicio Seccion del Carusel
        public ActionResult Carusel()
        {
            ViewData["WebActivo"] = "active";
            ViewData["Carusel"] = "active";
            return View();
        }
        CaruselDAL oCaruselDAL;
        [HttpPost]
        public ActionResult tablaCarusel()
        {
            oCaruselDAL = new CaruselDAL();
            List<CaruselModel> listCar = null;
            listCar = oCaruselDAL.ListaCarusel();
            return Json(new { listCar }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult nuevoCarusel(HttpPostedFileBase imagen, string tit1, string tit2)
        {
            if (ModelState.IsValid)
            {
                string rutaParaSubir = Server.MapPath("~\\images\\Carusel\\");
                int respuestaDeSubida = subirArchivo(imagen, rutaParaSubir);
                string nombreDeImagen = imagen.FileName.ToString();
                if (respuestaDeSubida == 1)
                {
                    oCaruselDAL = new CaruselDAL();
                    int respuestaDelServidorSQL = oCaruselDAL.Agregar(tit1, tit2, nombreDeImagen);
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
                    return Json(new { Value = false, Message = "Ocurrio un error al guardar la imagen en el Servidor" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult eliminarCarusel(int id)
        {
            if (ModelState.IsValid)
            {
                oCaruselDAL = new CaruselDAL();
                int respuestaServidorSQL = oCaruselDAL.Eliminar(id);
                if (respuestaServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Se ha eliminado correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al eliminar en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(new { Value = false, Message = "El código proporcionado es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult obtenerCarusel(int id)
        {
            if (ModelState.IsValid)
            {
                oCaruselDAL = new CaruselDAL();
                List<CaruselModel> listCar = null;
                listCar = oCaruselDAL.ObtenerCaruselUno(id);
                return Json(new { listCar }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { Value = false, Message = "El código proporcionado es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult cambiarConUrl(HttpPostedFileBase imagen, string tit1, string tit2, int id)
        {
            if (ModelState.IsValid)
            {
                string rutaParaSubir = Server.MapPath("~\\images\\Carusel\\");
                int respuestaDeSubida = subirArchivo(imagen, rutaParaSubir);
                string nombreDeImagen = imagen.FileName.ToString();
                if (respuestaDeSubida == 1)
                {
                    oCaruselDAL = new CaruselDAL();
                    int respuestaDelServidorSQL = oCaruselDAL.ModificarConURL(tit1, tit2, nombreDeImagen, id);
                    if (respuestaDelServidorSQL == 1)
                    {
                        return Json(new { Value = true, Message = "Se ha actualizado correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { Value = false, Message = "Ocurrio un error al actualizar en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al guardar la imagen en el Servidor" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult cambiarSinUrl(string tit1, string tit2, int id)
        {
            if (ModelState.IsValid)
            {
                oCaruselDAL = new CaruselDAL();
                int respuestaDelServidorSQL = oCaruselDAL.ModificarSinURL(tit1, tit2, id);
                if (respuestaDelServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Se ha actualizado correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al actualizar en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Fin de la Seccion del Carusel


        //Inicio seccion Principal
        public ActionResult Principal()
        {
            ViewData["WebActivo"] = "active";
            ViewData["Principal"] = "active";
            return View();
        }
        PrincipalDAL oPrincipalDAL;
        [HttpPost]
        public ActionResult tablaPrincipal()
        {
            oPrincipalDAL = new PrincipalDAL();
            List<PrincipalModel> listPrin = null;
            listPrin = oPrincipalDAL.ListaPrincipal();
            return Json(new { listPrin }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult nuevoPrincipal(HttpPostedFileBase imagen, string tit1, string negrita,string descrip)
        {
            if (ModelState.IsValid)
            {
                string rutaParaSubir = Server.MapPath("~\\images\\Principal\\");
                int respuestaDeSubida = subirArchivo(imagen, rutaParaSubir);
                string nombreDeImagen = imagen.FileName.ToString();
                if (respuestaDeSubida == 1)
                {
                    oPrincipalDAL = new PrincipalDAL();
                    int respuestaDelServidorSQL = oPrincipalDAL.Agregar(tit1, negrita, descrip, nombreDeImagen);
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
                    return Json(new { Value = false, Message = "Ocurrio un error al guardar la imagen en el Servidor" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult eliminarPrincipal(int id)
        {
            if (ModelState.IsValid)
            {
                oPrincipalDAL = new PrincipalDAL();
                int respuestaServidorSQL = oPrincipalDAL.Eliminar(id);
                if (respuestaServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Se ha eliminado correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al eliminar en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(new { Value = false, Message = "El código proporcionado es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult obtenerPrincipal(int id)
        {
            if (ModelState.IsValid)
            {
                oPrincipalDAL = new PrincipalDAL();
                List<PrincipalModel> listPrin = null;
                listPrin = oPrincipalDAL.obtenerPrincipalSeleccionado(id);
                return Json(new { listPrin }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { Value = false, Message = "El código proporcionado es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Fin Seccion Principal







        //Inicio Seccion Datos de Empresa
        public ActionResult DatosEmpresa()
        {
            ViewData["WebActivo"] = "active";
            ViewData["DatosEmpresa"] = "active";
            return View();
        }
        EmpresaDAL oEmpresaDAL;
        [HttpPost]
        public ActionResult obtenerEmpresa()
        {
            oEmpresaDAL = new EmpresaDAL();
            List<EmpresaModel> listEmpre = null;
            listEmpre = oEmpresaDAL.ObtenerEmpresa();
            return Json(new { listEmpre }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult actualizarEmpresa(string nombre, string desc, string direc, string tel, string correo, string sitio, string mision, string vision, string valores, int id)
        {
            if (ModelState.IsValid)
            {
                oEmpresaDAL = new EmpresaDAL();
                int respuestaDelServidorSQL = oEmpresaDAL.ModificarEmpresa(nombre, desc, direc, tel, correo, sitio, mision, vision, valores, id);
                if (respuestaDelServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Información del sitio actualizada correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al actualizar información en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Fin Seccion Datos de Empresa



        //Inicio Seccion Catalogos

        public ActionResult Catalogos()
        {
            ViewData["WebActivo"] = "active";
            ViewData["Catalogos"] = "active";
            return View();
        }
        CatalogosDAL oCatalogosDAL;
        [HttpPost]
        public ActionResult obtenerCatalogos()
        {
            oCatalogosDAL = new CatalogosDAL();
            List<CatalogoModel> listCat = null;
            listCat = oCatalogosDAL.ListaCatalogos();
            return Json(new { listCat }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult obtenerCatSelect(int id)
        {
            oCatalogosDAL = new CatalogosDAL();
            List<CatalogoModel> catSelec = null;
            catSelec = oCatalogosDAL.obtenerCatSelect(id);
            return Json(new { catSelec }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult guardarCat(HttpPostedFileBase pdf,string nombre)
        {
            if (ModelState.IsValid)
            {
                string rutaParaSubir = Server.MapPath("~\\Catalogos\\");
                int respuestaDeSubida = subirArchivo(pdf, rutaParaSubir);
                string nombreDeFile = pdf.FileName.ToString();
                if (respuestaDeSubida == 1)
                {
                    //return Json(new { Value = true, Message = "Se ha guardado correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                    oCatalogosDAL = new CatalogosDAL();
                    int respuestaDelServidorSQL = oCatalogosDAL.Agregar(nombre, nombreDeFile);
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
                    return Json(new { Value = false, Message = "Ocurrio un error al guardar archivo en el Servidor" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ModificarNombre(string nombre ,int id)
        {
            if (ModelState.IsValid)
            {
                //return Json(new { Value = true, Message = "Se ha guardado correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                oCatalogosDAL = new CatalogosDAL();
                int respuestaDelServidorSQL = oCatalogosDAL.ModificarNombre(nombre,id);
                if (respuestaDelServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Datos actualizados correctamente en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al actualizar en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult ModificarTodo(HttpPostedFileBase pdf,string nombre,int id)
        {
            if (ModelState.IsValid)
            {
                string rutaParaSubir = Server.MapPath("~\\Catalogos\\");
                int respuestaDeSubida = subirArchivo(pdf, rutaParaSubir);
                string nombreDeFile = pdf.FileName.ToString();
                if (respuestaDeSubida == 1)
                {
                    oCatalogosDAL = new CatalogosDAL();
                    int respuestaDelServidorSQL = oCatalogosDAL.ModificarTodo(nombreDeFile, nombre, id);
                    if (respuestaDelServidorSQL == 1)
                    {
                        return Json(new { Value = true, Message = "Datos actualizados correctamente" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { Value = false, Message = "Ocurrio un error al actualizar en la Base de Datos" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { Value = false, Message = "Ocurrio un error al altualizar archivo en el Servidor" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Value = false, Message = "Uno de los datos es incorrecto" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Estatus(int id,string val)
        {
            if (ModelState.IsValid)
            {
                int sta = 0;
                string letra;
                if(val=="1")
                {
                    sta = 0;
                    letra = "desactivado";
                }
                else
                {
                    sta = 1;
                    letra = "activado";
                }
                oCatalogosDAL = new CatalogosDAL();
                int respuestaDelServidorSQL = oCatalogosDAL.cambiarEstatus(id, sta);
                if (respuestaDelServidorSQL == 1)
                {
                    return Json(new { Value = true, Message = "Estatus "+letra+" correctamente" }, JsonRequestBehavior.AllowGet);
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
        //Fin Seccion Catalogos










        public string dataTableToJson(DataTable tabla)
        {
            string DatosJson = String.Empty;
            DatosJson = JsonConvert.SerializeObject(tabla);
            return DatosJson;
        }
        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }

        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

        private int subirArchivo(HttpPostedFileBase file,string rutaParaGuardar)
        {
            try
            {
                //Si el directorio o ruta no existe secrea una con el siguiente codigo
                //if(!Directory.Exists(path))
                //{
                //    Directory.CreateDirectory(path);
                //}
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
