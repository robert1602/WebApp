using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class SucursalCLS
    {
        [Display(Name = "Id Sucursal")]
        public int iidSucursal { get; set; }

        [Display(Name = "Nombre Sucursal")]
        public string nombre { get; set; }

        [Display(Name = "Direccion Sucursal")]
        public string direccion { get; set; }

        [Display(Name = "Telefono Sucursal")]
        public int telefono { get; set; }

        [Display(Name = "Email sucursal")]
        public string email { get; set; }

        [Display(Name = "Fecha Apertura")]
        public DateTime fechaApertura { get; set; }

        [Display(Name = "Habilitado")]
        public int dhabilitado { get; set; }
     
    }
}