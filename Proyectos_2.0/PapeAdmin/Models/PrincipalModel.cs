﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapeAdmin.Models
{
    public class PrincipalModel
    {
        public int idPrincipal { get; set; }
        public string titulo1 { get; set; }
        public string negrita { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public int statusPrincipal { get; set; }

    }
}