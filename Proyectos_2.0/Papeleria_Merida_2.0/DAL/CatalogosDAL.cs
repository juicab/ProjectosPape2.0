using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Papeleria_Merida_2._0.Models;

namespace Papeleria_Merida_2._0.DAL
{
    public class CatalogosDAL
    {
        ConexionDAL oConexionDAL;
        public CatalogosDAL() { oConexionDAL = new ConexionDAL(); }

        public DataTable Mostrar()
        {
            return oConexionDAL.TablaConnsulta("select idCatalogo,nombreCat,docuCat,FORMAT(fechaCat, 'dd/MMMMM/yyyy', 'ES-ES' ) as 'fechaCat',statusCat from Catalogo where statusCat=1");
        }

        public List<CatalogoModel> ListaCatalogos()
        {
            string query = "select idCatalogo,nombreCat,docuCat,FORMAT(fechaCat, 'dd/MMMMM/yyyy', 'ES-ES' ) as 'fechaCat',statusCat from Catalogo";
            var result = oConexionDAL.TablaConnsulta(query);
            List<CatalogoModel> listaCat = new List<CatalogoModel>();
            foreach (DataRow catalogo in result.Rows)
            {
                var catalogos = new CatalogoModel();
                catalogos.idCatalogo = int.Parse(catalogo[0].ToString());
                catalogos.nombreCat = catalogo[1].ToString();
                catalogos.docuCat = catalogo[2].ToString();
                catalogos.fechaCat = catalogo[3].ToString();
                catalogos.statusCat = int.Parse(catalogo[4].ToString());
                listaCat.Add(catalogos);
            }
            return listaCat;
        }

        public List<CatalogoModel> obtenerCatSelect(int id)
        {
            string query = "select idCatalogo,nombreCat,docuCat,FORMAT(fechaCat, 'dd/MMMMM/yyyy', 'ES-ES' ) as 'fechaCat',statusCat from Catalogo where idCatalogo=" + id;
            var result = oConexionDAL.TablaConnsulta(query);
            List<CatalogoModel> listaCat = new List<CatalogoModel>();
            foreach (DataRow catalogo in result.Rows)
            {
                var catalogos = new CatalogoModel();
                catalogos.idCatalogo = int.Parse(catalogo[0].ToString());
                catalogos.nombreCat = catalogo[1].ToString();
                catalogos.docuCat = catalogo[2].ToString();
                catalogos.fechaCat = catalogo[3].ToString();
                catalogos.statusCat = int.Parse(catalogo[4].ToString());
                listaCat.Add(catalogos);
            }
            return listaCat;
        }

        public DataTable MostrarParaMaster()
        {
            return oConexionDAL.TablaConnsulta("select idCatalogo,nombreCat from Catalogo where statusCat=1");
        }

        public CatalogoModel ObtenerCatalogoSeleccionado(int id)
        {
            var Catalogo = new CatalogoModel();
            string StrBuscar = string.Format("select * from Catalogo where idCatalogo=" + id + "");
            DataTable Datos = oConexionDAL.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            Catalogo.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
            Catalogo.nombreCat = row["nombreCat"].ToString();
            Catalogo.docuCat = row["docuCat"].ToString();
            DateTime f = Convert.ToDateTime(row["fechaCat"]);
            string dia = f.Day.ToString();
            string mes = MesEscrito(f.Month.ToString());
            string an = f.Year.ToString();
            string fet = dia + "-" + mes + "-" + an;
            Catalogo.fechaCat = fet.ToString();
            Catalogo.statusCat = Convert.ToInt32(row["statusCat"]);
            return Catalogo;
        }
        public int ModificarUrl(string url, int id)
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string an = DateTime.Now.Year.ToString();
            string fch = an + "-" + mes + "-" + dia;
            string query = "UPDATE [dbo].[Catalogo] SET [docuCat] = '" + url + "' ,[fechaCat] = '" + fch + "' WHERE idCatalogo=" + id;
            return oConexionDAL.EjecutarSQL(query);
        }

        public int ModificarTodo(string url, string nombre, int id)
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string an = DateTime.Now.Year.ToString();
            string fch = an + "-" + mes + "-" + dia;
            string query = "UPDATE [dbo].[Catalogo] SET [docuCat] = '" + url + "' ,[nombreCat] = '" + nombre + "',[fechaCat] = '" + fch + "' WHERE idCatalogo=" + id;
            return oConexionDAL.EjecutarSQL(query);
        }

        public int ModificarNombre(string nombre, int id)
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string an = DateTime.Now.Year.ToString();
            string fch = an + "-" + mes + "-" + dia;
            string query = "UPDATE [dbo].[Catalogo] SET [nombreCat] = '" + nombre + "' WHERE idCatalogo=" + id;
            return oConexionDAL.EjecutarSQL(query);
        }

        public int Agregar(string nombre, string docu)
        {
            int id = (ultimo() + 1);
            string fechas = DateTime.Now.Date.ToString();
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string an = DateTime.Now.Year.ToString();
            string fch = an + "-" + mes + "-" + dia;
            string query = "INSERT INTO [dbo].[Catalogo]([idCatalogo],[nombreCat],[docuCat],[fechaCat],[statusCat])VALUES(" + id + ",'" + nombre + "','" + docu + "','" + fch + "',1)";
            return oConexionDAL.EjecutarSQL(query);
        }

        public int ultimo()
        {
            string query = "select top 1 idCatalogo,nombreCat,docuCat,FORMAT(fechaCat, 'dd/MMMMM/yyyy', 'ES-ES' ) as 'fechaCat',statusCat from Catalogo order by idCatalogo desc";
            var result = oConexionDAL.TablaConnsulta(query);
            int id = 0;
            List<CatalogoModel> listaCat = new List<CatalogoModel>();
            foreach (DataRow catalogo in result.Rows)
            {
                var catalogos = new CatalogoModel();
                id = int.Parse(catalogo[0].ToString());
                catalogos.idCatalogo = int.Parse(catalogo[0].ToString());
                catalogos.nombreCat = catalogo[1].ToString();
                catalogos.docuCat = catalogo[2].ToString();
                catalogos.fechaCat = catalogo[3].ToString();
                catalogos.statusCat = int.Parse(catalogo[4].ToString());
                listaCat.Add(catalogos);
            }
            return id;
        }

        public string MesEscrito(string num)
        {
            string dia;
            if (num == "1")
            {
                dia = "Enero";
                return dia;
            }
            else
            {
                if (num == "2")
                {
                    dia = "Febrero";
                    return dia;
                }
                else
                {
                    if (num == "3")
                    {
                        dia = "Marzo";
                        return dia;
                    }
                    else
                    {
                        if (num == "4")
                        {
                            dia = "Abril";
                            return dia;
                        }
                        else
                        {
                            if (num == "5")
                            {
                                dia = "Mayo";
                                return dia;
                            }
                            else
                            {
                                if (num == "6")
                                {
                                    dia = "Junio";
                                    return dia;
                                }
                                else
                                {
                                    if (num == "7")
                                    {
                                        dia = "Julio";
                                        return dia;
                                    }
                                    else
                                    {
                                        if (num == "8")
                                        {
                                            dia = "Agosto";
                                            return dia;
                                        }
                                        else
                                        {
                                            if (num == "9")
                                            {
                                                dia = "Septiembre";
                                                return dia;
                                            }
                                            else
                                            {
                                                if (num == "10")
                                                {
                                                    dia = "Octubre";
                                                    return dia;
                                                }
                                                else
                                                {
                                                    if (num == "11")
                                                    {
                                                        dia = "Noviembre";
                                                        return dia;
                                                    }
                                                    else
                                                    {
                                                        if (num == "12")
                                                        {
                                                            dia = "Diciembre";
                                                            return dia;
                                                        }
                                                        else
                                                        {
                                                            dia = "Error";
                                                            return dia;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        public int cambiarEstatus(int id, int status)
        {
            string query = "update Catalogo set statusCat=" + status + " where idCatalogo=" + id;
            return oConexionDAL.EjecutarSQL(query);
        }
    }
}