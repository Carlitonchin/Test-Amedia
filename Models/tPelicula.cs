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

        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal precio_alquiler { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal precio_venta { get; set; }

        public List<tAlquiler> alquileres { get; set; }
        public List<tVenta> ventas { get; set; }
        public List<tGeneroPelicula> generos { get; set; }

    }
}
