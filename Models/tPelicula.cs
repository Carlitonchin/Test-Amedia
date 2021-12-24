using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models
{
    public class tPelicula
    {
        [Key]
        public int cod_pelicula { get; set; }
        [Display(Name ="Nombre")]
        [MaxLength(500)]
        public string txt_desc { get; set; }

        [Display(Name ="Cantidad disponible para alquiler")]
        public int cant_disponibles_alquiler { get; set; }
        
        [Display(Name ="Cantidad disponible para venta")]
        public int cant_disponibles_venta { get; set; }

        [DataType(DataType.Currency)]
        public float precio_alquiler { get; set; }

        [DataType(DataType.Currency)]
        public float precio_venta { get; set; }

        public List<tAlquiler> alquileres { get; set; }
        public List<tVenta> ventas { get; set; }
        public List<tGeneroPelicula> generos { get; set; }

    }
}
