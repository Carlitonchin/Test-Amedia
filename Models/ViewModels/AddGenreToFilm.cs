using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models.ViewModels
{
    public class AddGenreToFilm
    {
        public tPelicula film { get; set; }
        public IEnumerable<tGenero> genres { get; set; }

        public AddGenreToFilm(tPelicula film, IEnumerable<tGenero> genres) 
        {
            this.film = film;
            this.genres = genres;
        }
    }
}
