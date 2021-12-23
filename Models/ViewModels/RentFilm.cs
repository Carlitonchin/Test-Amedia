using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models.ViewModels
{
    public class RentFilm
    {
        public tPelicula film { get; set; }
        public tAlquiler rent { get; set; }

        public RentFilm(tPelicula film, tAlquiler rent) 
        {
            this.film = film;
            this.rent = rent;
        }
    }
}
