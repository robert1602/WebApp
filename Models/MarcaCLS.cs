﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class MarcaCLS
    {  
        [Display (Name ="Id Marca")]
        public int iidMarca { get; set; }

        [Display(Name = "Nombre Marca")]
        public string nombre { get; set; }

        [Display(Name = "Descripcion Marca")]
        public string descripcion { get; set; }

        public int bhabilitado { get; set; }
        
    }
}