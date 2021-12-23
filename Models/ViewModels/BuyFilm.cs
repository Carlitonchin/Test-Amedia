using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models.ViewModels
{
    public class BuyFilm
    {
        public tPelicula film { get; set; }
        public tVenta buy { get; set; }

        public BuyFilm(tPelicula film, tVenta buy)
        {
            this.film = film;
            this.buy = buy;
        }
    }
}
