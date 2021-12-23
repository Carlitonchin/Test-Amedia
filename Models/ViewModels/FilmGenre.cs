using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models.ViewModels
{
    public class FilmGenre
    {
        public FilmGenre(tPelicula film, tGenero genre, int filmId) 
        {
            this.film = film;
            this.genre = genre;
            this.filmId = filmId;
        }

        public int filmId { get; set; }
        public tPelicula film { get; set; }
        public tGenero genre { get; set; }
    }
}
