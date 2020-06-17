using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapeAdmin.Models
{
    public class CaruselModel
    {
        public int idCarusel { get; set; }
        public string titulo1 { get; set; }
        public string titulo2 { get; set; }
        public string urlCarusel { get; set; }
        public int statusCarusel { get; set; }
        public List<CaruselModel> listaCarusel { get; set; }
    }
}