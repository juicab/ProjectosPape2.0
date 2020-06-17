using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PapeAdmin.Models;
using System.Data;

namespace PapeAdmin.DAL
{
    public class PrincipalDAL
    {
        ConexionDAL oConexionDAL;
        public PrincipalDAL() { oConexionDAL = new ConexionDAL(); }
        public int Agregar(string titulo1, string negrita, string descripcion,string imagen)
        {
            string query = "INSERT INTO [padmin].[Principal]([titulo1],[negrita],[descripcion],[imagen],[statusPrincipal]) VALUES ('"+titulo1+"','"+negrita+"','"+descripcion+"','"+imagen+"',1)";
            return oConexionDAL.EjecutarSQL(query);
        }

        public int ModificarConURL(string titulo1, string negrita, string descripcion, string imagen, int id)
        {
            string query = "UPDATE [padmin].[Principal] SET [titulo1] = '"+titulo1+"', [negrita] = '"+negrita+"', [descripcion] = '"+descripcion+"',[imagen] = '"+imagen+"' WHERE idPrincipal="+id;
            return oConexionDAL.EjecutarSQL(query);
        }
        public int ModificarSinURL(string titulo1, string negrita, string descripcion, int id)
        {
            string query = "UPDATE [padmin].[Principal] SET [titulo1] = '" + titulo1 + "', [negrita] = '" + negrita + "', [descripcion] = '" + descripcion + "' WHERE idPrincipal=" + id;
            return oConexionDAL.EjecutarSQL(query);
        }

        public int Eliminar(int id)
        {
            string query = "UPDATE [padmin].[Principal] SET [statusPrincipal] = 0 WHERE idPrincipal="+id;
            return oConexionDAL.EjecutarSQL(query);
        }

        public DataTable Mostrar()
        {
            return oConexionDAL.TablaConnsulta("Select * from Principal where statusPrincipal=1 order by idPrincipal desc");
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
        
        public List<PrincipalModel> ListaPrincipal()
        {
            string query = "select * from Principal where statusPrincipal=1 order by idPrincipal desc";
            var result = oConexionDAL.TablaConnsulta(query);
            List<PrincipalModel> listaPrincipal = new List<PrincipalModel>();
            foreach(DataRow principal in result.Rows)
            {
                var principales = new PrincipalModel();
                principales.idPrincipal = int.Parse(principal[0].ToString());
                principales.titulo1 = principal[1].ToString();
                principales.negrita = principal[2].ToString();
                principales.descripcion = principal[3].ToString();
                principales.imagen = principal[4].ToString();
                principales.statusPrincipal = int.Parse(principal[5].ToString());
                listaPrincipal.Add(principales);
            }
            return listaPrincipal;

        }

        public List<PrincipalModel> obtenerPrincipalSeleccionado(int id)
        {
            string query = "select * from Principal where idPrincipal="+id;
            var result = oConexionDAL.TablaConnsulta(query);
            List<PrincipalModel> listaPrincipal = new List<PrincipalModel>();
            foreach (DataRow principal in result.Rows)
            {
                var principales = new PrincipalModel();
                principales.idPrincipal = int.Parse(principal[0].ToString());
                principales.titulo1 = principal[1].ToString();
                principales.negrita = principal[2].ToString();
                principales.descripcion = principal[3].ToString();
                principales.imagen = principal[4].ToString();
                principales.statusPrincipal = int.Parse(principal[5].ToString());
                listaPrincipal.Add(principales);
            }
            return listaPrincipal;

        }

    }
}