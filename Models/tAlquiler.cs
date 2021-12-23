using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models
{
    public class tAlquiler
    {
        [Key]
        public int cod_adquiler { get; set; }
        public decimal precio { get; set; }
        public DateTime momento { get; set; }
        public int cod_usuario { get; set; }
        public tUsers usuario { get; set; }
        public int cod_pelicula { get; set; }
        public tPelicula pelicula { get; set; }
    }
}
