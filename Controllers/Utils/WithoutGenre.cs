using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Crud_Carlos_Arrieta.Data;

namespace Test_Crud_Carlos_Arrieta.Controllers.Utils
{
    public class WithoutGenre : Controller
    {
        private readonly ApplicationDbContext _context;

        public WithoutGenre(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Asign(int idFilm) 
        {

            var r =  from g in _context.tGenero
                          where g.txt_desc == "Sin Genero"
                          select g;

            var h = r.ToList();

            var film = new SqlParameter("@filmId", idFilm);
            var genre = new SqlParameter("@genreId", r.ToList()[0].cod_genero);

            await _context.tGeneroPelicula.FromSqlRaw("exec setGenreToThisFilm @filmId, @genreId", film, genre).ToListAsync();
        }
    }
}
