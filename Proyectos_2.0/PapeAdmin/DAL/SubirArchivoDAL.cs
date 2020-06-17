using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace PapeAdmin.DAL
{
    public class SubirArchivoDAL
    {
        public int subirImagenFTP(HttpPostedFileBase imagen,string ruta)
        {
            string server = "ftp://107.180.0.7";
            string rutadestino = "/papeleriamerida.com.mx/images/Carusel";
            string nombredestino = imagen.FileName;
            string RutaArchivoCompu = ruta;
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(server + rutadestino + "/" + nombredestino);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("ph17069950603", "Cs18191819");
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                FileStream stream = File.OpenRead(RutaArchivoCompu);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Flush();
                reqStream.Close();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
    }
}