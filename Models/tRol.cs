using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models
{
    public class tRol
    {
        [Key]
        public int cod_rol { get; set; }

        [MaxLength(500)]
        [Display(Name ="Rol")]
        public string txt_desc { get; set; }
        public int sn_activo { get; set; }
        public List<tUsers> users { get; set; }
    }
}
