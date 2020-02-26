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
        [StringLength(100, ErrorMessage = "La longitud maxima es 100")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Direccion Sucursal")]
        [StringLength(200, ErrorMessage = "La longitud maxima es 200")]
        [Required]
        public string direccion { get; set; }

        [Display(Name = "Telefono Sucursal")]
        [Required]
        [StringLength(10, ErrorMessage = "La longitud maxima es 10")]
        public string telefono { get; set; }


        [Display(Name = "Email sucursal")]      
        [Required]
        [StringLength(100, ErrorMessage = "La longitud maxima es 100")]
        [EmailAddress(ErrorMessage ="Ingrese un email valido")]
        public string email { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name = "Fecha Apertura")]         
        public DateTime fechaApertura { get; set; }


        [Display(Name = "Habilitado")]
        public int dhabilitado { get; set; }
     
    }
}