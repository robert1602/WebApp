using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ViajeCLS
    {
        public int Iidviaje { get; set; }
        [Required]
        [Display(Name = "Id Viaje")]
        public int IiLugarOrigen { get; set; }
        [Required]
        [Display(Name = "Lugar Origen")]
        public int IiLugarDestino { get; set; }
        [Required]
        [Display(Name = "Lugar Destino")]
        public decimal precio { get; set; }
        [Required]
        [Range(0, 10000000,ErrorMessage ="Valor fuera de rango")]
        [Display(Name = "Precio")]
        public DateTime fechaviaje { get; set; }
        [Required]
        [Display(Name = "Fecha Viaje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="0,yyyy-MM-dd",ApplyFormatInEditMode =true)]
        public int Iidbus { get; set; }
        [Required]
        [Display(Name = "Id Bus")]
        public int numeroDasientosDisponibles { get; set; }
        [Required]
        [Display(Name = "N° de Asientos")]

        public int Bhabilitado { get; set; }

        //Propiedades adicionales

        [Required]
        [Display(Name = "Lugar Origen")]
        public string nombreLugarOrigen { get; set; }

        [Required]
        [Display(Name = "Lugar Destino")]
        public string nombreLugarDestino { get; set; }

        [Required]
        [Display(Name = "Nombre Bus")]
        public string nombreBus { get; set; }
    }
}