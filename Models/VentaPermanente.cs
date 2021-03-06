using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models
{
    public class VentaPermanente
    {
        [Key]
        public int id { get; set; }

        public int filmId { get; set; }
        
        [DataType(DataType.Currency)]
        public float price { get; set; }
    }
}
