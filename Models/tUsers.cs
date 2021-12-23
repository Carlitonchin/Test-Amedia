using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models
{
    public class tUsers
    {
        [Key]
        public int cod_usuario { get; set; }

        [Display(Name = "Nombre de Usuario")]
        [MaxLength(50)]
        public string txt_user { get; set; }

        [Display(Name = "Contraseña")]
        [MaxLength(50)]
        public string txt_password { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(200)]
        public string txt_nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(200)]
        public string txt_apellido { get; set; }

        [Display(Name = "# de documento")]
        [MaxLength(50)]
        [Required]
        public string nro_doc { get; set; }
        public int sn_activo { get; set; }

        public int cod_rol { get; set; }
        public tRol trol { get; set; }

        public List<tAlquiler> alquileres { get; set; }
        public List<tVenta> compras { get; set; }
    }
}