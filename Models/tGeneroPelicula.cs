using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models
{
    public class tGeneroPelicula
    {
        [Key]
        public int cod_genero_pelicula { get; set; }
        public int cod_pelicula { get; set; }
        public tPelicula pelicula { get; set; }
        public int cod_genero { get; set; }
        public tGenero genero { get; set; }
    }
}
