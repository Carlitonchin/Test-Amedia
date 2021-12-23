using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models
{
    public class VentaPermanente
    {
        [Key]
        public int id { get; set; }

        public int filmId { get; set; }
        public decimal price { get; set; }
    }
}
