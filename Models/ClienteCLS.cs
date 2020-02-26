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

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(100, ErrorMessage = "Longitud Maxima 100")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        [StringLength(150, ErrorMessage = "Longitud Maxima 150")]
        public string apPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        [StringLength(150, ErrorMessage = "Longitud Maxima 150")]
        public string apMaterno { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        public string Direccion { get; set; }


        [Required]
        [Display(Name = " Sexo")]
        public int? Iidsexo{ get; set; }

        [Required]
        [Display(Name = "Telefono Fijo")]
        [StringLength(10, ErrorMessage = "Longitud Maxima 10 Numeros")]
        public string TelefonoFijo { get; set; }

        [Required]
        [Display(Name = "Telefono Celular")]
        [StringLength(10, ErrorMessage = "Longitud Maxima 10 Numeros")]
        public string Telefonocelular { get; set; }
        

    }
}
