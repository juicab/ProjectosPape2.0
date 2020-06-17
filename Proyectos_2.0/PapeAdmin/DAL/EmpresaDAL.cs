using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PapeAdmin.Models;
using System.Data;

namespace PapeAdmin.DAL
{
    public class EmpresaDAL
    {
        ConexionDAL oConexionDAL;
        public EmpresaDAL() { oConexionDAL = new ConexionDAL(); }

        public List<EmpresaModel> ObtenerEmpresa()
        {
            string query = "select * from Empresa";
            var result = oConexionDAL.TablaConnsulta(query);
            List<EmpresaModel> listaEmpresa = new List<EmpresaModel>();
            foreach (DataRow datos in result.Rows)
            {
                var empresas = new EmpresaModel();
                empresas.idEmpresa = int.Parse(datos[0].ToString());
                empresas.nombre = datos[1].ToString();
                empresas.descripcion =datos[2].ToString();
                empresas.direccion =datos[3].ToString();
                empresas.telefono =datos[4].ToString();
                empresas.correo =datos[5].ToString();
                empresas.sitio=datos[6].ToString();
                empresas.mision=datos[7].ToString();
                empresas.vision=datos[8].ToString();
                empresas.valores =datos[9].ToString();
                empresas.statusEmpresa =int.Parse(datos[10].ToString());
                listaEmpresa.Add(empresas);
            }
            return listaEmpresa;
        }

        public int ModificarEmpresa(string nombre,string desc,string direc,string tel,string correo, string sitio,string mision, string vision,string valores, int id)
        {
            string query = "UPDATE [dbo].[Empresa] SET [nombre] = '"+nombre+"',[descripcion] = '"+desc+"',[direccion] = '"+direc+"',[telefono] = '"+tel+"',[correo] = '"+correo+"',[sitio] = '"+sitio+"',[mision] = '"+mision+"',[vision] = '"+vision+"',[valores] = '"+valores+"' WHERE idEmpresa="+id;
            return oConexionDAL.EjecutarSQL(query);
        }





    }
}