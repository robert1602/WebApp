using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmpleadoCLS
    {
        [Display(Name = "Id Empleado")]
        public int Iiempleado { get; set; }

        [Required]
        [Display(Name = "Nombre Empleado")]
        [StringLength(100, ErrorMessage = "Longitud Maxima 100")]
        public string nombreEmpleado { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        public string aPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        public string apMaterno { get; set; }


        [Required]
        [Display(Name = "Fecha Contrato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fechaContrato { get; set; }


        [Required]
        [Range(0,10000000,ErrorMessage ="Valor fuera de rango")]
        [Display(Name = "Sueldo")]
        public decimal sueldo { get; set; }


        [Required]
        [Display(Name = "Tipo Usuario")]
        public int Iidtipousuario{ get; set; }


        [Required]
        [Display(Name = "Tipo Contrato")]
        public int Iidtipocontrato{ get; set; }


        [Required]
        [Display(Name = "Sexo")]
        public int Iidsexo { get; set; }

        public int bhabilitado { get; set; }


        //Propiedades adicionales
        //[Required]
        //[Display(Name = "Tipo Usuario")]
        public string nombreTipoUsuario { get; set; }

        //[Required]
        //[Display(Name = "Tipo Contrato")]
        public string nombreTipoContrato { get; set; }


    }
}

