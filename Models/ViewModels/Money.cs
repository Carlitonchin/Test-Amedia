using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models.ViewModels
{
    public class Money
    {
        public tPelicula film { get; set; }
        public List<VentaPermanente> buy { get; set; }
        public List<AlquilerPermanente> rent { get; set; }
       

        public Money(tPelicula f, List<VentaPermanente> b, List<AlquilerPermanente> r) 
        {
            this.film = f;
            this.buy = b;
            this.rent = r;
        }
    }
}
