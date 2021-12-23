using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models
{
    public class tGenero
    {
        [Key]
        public int cod_genero { get; set; } 
        
        [Display(Name ="Genero")]
        [MaxLength(500)]
        public string txt_desc { get; set; }
        public List<tGeneroPelicula> peliculas { get; set; }
    }
}
