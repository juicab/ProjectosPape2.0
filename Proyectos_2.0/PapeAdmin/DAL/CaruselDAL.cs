﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PapeAdmin.Models;
using System.Data;

namespace PapeAdmin.DAL
{
    public class CaruselDAL
    {
        ConexionDAL oConexionDAL;
        public CaruselDAL() { oConexionDAL = new ConexionDAL(); }
        public int Agregar(string titulo1, string titulo2, string url)
        {
            string query = "INSERT INTO [padmin].[Carusel]([titulo1],[titulo2],[urlCarusel],[statusCarusel])VALUES ('" + titulo1 + "','" + titulo2 + "','" + url + "',1)";
            return oConexionDAL.EjecutarSQL(query);
        }

        public int ModificarConURL(string titulo1, string titulo2, string url, int id)
        {
            string query = "UPDATE [padmin].[Carusel]SET [titulo1] = '" + titulo1 + "',[titulo2] ='" + titulo2 + "',[urlCarusel] = '" + url + "' WHERE idCarusel=" + id + "";
            return oConexionDAL.EjecutarSQL(query);
        }
        public int ModificarSinURL(string titulo1, string titulo2, int id)
        {
            string query = "UPDATE [padmin].[Carusel]SET [titulo1] = '" + titulo1 + "',[titulo2] ='" + titulo2 + "' WHERE idCarusel=" + id + "";
            return oConexionDAL.EjecutarSQL(query);
        }

        public int Eliminar(int id)
        {
            string query = "UPDATE [padmin].[Carusel]SET [statusCarusel] =0 WHERE idCarusel=" + id + "";
            return oConexionDAL.EjecutarSQL(query);
        }

        public DataTable Mostrar()
        {
            return oConexionDAL.TablaConnsulta("select * from Carusel where statusCarusel=1 order by idCarusel desc");
        }

        public CaruselModel ObtenerCaruselSeleccionado(int id)
        {
            var Carusel = new CaruselModel();
            String StrBuscar = string.Format("select * from Carusel where idCarusel=" + id + "");
            DataTable Datos = oConexionDAL.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            Carusel.idCarusel = Convert.ToInt32(row["idCarusel"]);
            Carusel.titulo1 = row["titulo1"].ToString();
            Carusel.titulo2 = row["titulo2"].ToString();
            Carusel.urlCarusel = row["urlCarusel"].ToString();
            Carusel.statusCarusel = Convert.ToInt32(row["statusCarusel"]);
            return Carusel;
        }

        public List<CaruselModel>ListaCarusel()
        {
            string query = "select * from Carusel where statusCarusel=1 order by idCarusel desc";
            var result = oConexionDAL.TablaConnsulta(query);
            List<CaruselModel> listaCarusel = new List<CaruselModel>();
            foreach(DataRow carusel in result.Rows)
            {
                var caruseles = new CaruselModel();
                caruseles.idCarusel = int.Parse(carusel[0].ToString());
                caruseles.titulo1 = carusel[1].ToString();
                caruseles.titulo2 = carusel[2].ToString();
                caruseles.urlCarusel = carusel[3].ToString();
                caruseles.statusCarusel =int.Parse(carusel[4].ToString());
                listaCarusel.Add(caruseles);
            }
            return listaCarusel;
        }

        public List<CaruselModel>ObtenerCaruselUno(int id)
        {
            string query = "select * from Carusel where statusCarusel=1 and idCarusel="+id.ToString();
            var result = oConexionDAL.TablaConnsulta(query);
            List<CaruselModel> listaCarusel = new List<CaruselModel>();
            foreach (DataRow carusel in result.Rows)
            {
                var caruseles = new CaruselModel();
                caruseles.idCarusel = int.Parse(carusel[0].ToString());
                caruseles.titulo1 = carusel[1].ToString();
                caruseles.titulo2 = carusel[2].ToString();
                caruseles.urlCarusel = carusel[3].ToString();
                caruseles.statusCarusel = int.Parse(carusel[4].ToString());
                listaCarusel.Add(caruseles);
            }
            return listaCarusel;
        }


    }
}