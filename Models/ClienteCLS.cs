using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Id Cliente")]
        public int iidcliente { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        public string apPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string apMaterno { get; set; }

        public string telefonoFijo { get; set; }

    }
}