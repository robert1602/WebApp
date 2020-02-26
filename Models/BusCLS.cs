using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class BusCLS
    {
        public int Iidbus { get; set; }
        [Display(Name = "Id Bus")]

        public DateTime fechacompra { get; set; }
        [Required]
        [Display(Name = "Fecha compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public string placa { get; set; }
        [Required]
        [Display(Name = "Placa")]

        public int Iidmodelo { get; set; }
        [Required]
        [Display(Name = "Id Modelo")]

        public int numerofilas { get; set; }
        [Required]
        [Display(Name = "Numero de filas")]

        public int numerocolumnas { get; set; }
        [Required]
        [Display(Name = "Numero de Columnas")]

        public string DESCRIPCION { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [StringLength(200, ErrorMessage = "Longitud Maxima  200")]

        public string OBSERVACION { get; set; }
        [Required]
        [Display(Name = "Observación")]
        [StringLength(200, ErrorMessage = "Longitud Maxima de 200")]

        public int IIDMARCA { get; set; }
        [Required]
        [Display(Name = "Nombre Marca")]

        public int bhabilitado { get; set; }


        //Propiedades adicionales
        [Required]
        [Display(Name = "Nombre Sucursal")]
        public string nombreSucursal { get; set; }

        [Required]
        [Display(Name = "Tipo Bus")]
        public string nombreTipoBus { get; set; }

        [Required]
        [Display(Name = "Nombre Modelo")]
        public string nombreModelo { get; set; }

    }
}