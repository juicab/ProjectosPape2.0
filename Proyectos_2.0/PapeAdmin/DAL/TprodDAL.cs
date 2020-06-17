using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PapeAdmin.Models;

namespace PapeAdmin.DAL
{
    public class TprodDAL
    {
        ConexionDAL oConexionDAL;
        public TprodDAL() { oConexionDAL = new ConexionDAL(); }

        public int Agregar(string Tprod)
        {
            string query = "INSERT INTO [padmin].[Tprod]([tProd],[statusTprod])VALUES('" + Tprod + "',1)";
            return oConexionDAL.EjecutarSQL(query);
        }

        public int Editar(string Tprod, int id)
        {
            string query = "UPDATE [padmin].[Tprod] SET [tProd] = '" + Tprod + "' WHERE idTprod=" + id;
            return oConexionDAL.EjecutarSQL(query);
        }

        public int Eliminar(int id)
        {
            string query = "UPDATE [padmin].[Tprod] SET [statusTprod] = 0 WHERE idTprod=" + id;
            return oConexionDAL.EjecutarSQL(query);
        }

        public List<TprodModel> ListaTprod()
        {
            string query = "select * from Tprod where statusTprod=1";
            var result = oConexionDAL.TablaConnsulta(query);
            List<TprodModel> listaTprod = new List<TprodModel>();
            foreach (DataRow tProd in result.Rows)
            {
                var tProds = new TprodModel();
                tProds.idTprod = int.Parse(tProd[0].ToString());
                tProds.Tprod = tProd[1].ToString();
                tProds.statusTprod = int.Parse(tProd[2].ToString());
                listaTprod.Add(tProds);
            }
            return listaTprod;
        }

        public List<TprodModel> seleccionar(int id)
        {
            string query = "select * from Tprod where idTprod=" + id;
            var result = oConexionDAL.TablaConnsulta(query);
            List<TprodModel> listaTprod = new List<TprodModel>();
            foreach (DataRow tProd in result.Rows)
            {
                var tProds = new TprodModel();
                tProds.idTprod = int.Parse(tProd[0].ToString());
                tProds.Tprod = tProd[1].ToString();
                tProds.statusTprod = int.Parse(tProd[2].ToString());
                listaTprod.Add(tProds);
            }
            return listaTprod;


        }
    }
}