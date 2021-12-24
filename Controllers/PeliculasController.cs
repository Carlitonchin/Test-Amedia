using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Test_Crud_Carlos_Arrieta.Controllers.Utils;
using Test_Crud_Carlos_Arrieta.Data;
using Test_Crud_Carlos_Arrieta.Models;
using Test_Crud_Carlos_Arrieta.Models.ViewModels;

namespace Test_Crud_Carlos_Arrieta.Controllers
{

    public class PeliculasController : Controller
    {

        public async Task<bool> Can()
        {
            var roleController = new RoleController(_context);
            byte[] bytes = null;
            HttpContext.Session.TryGetValue("user", out bytes);
            if (bytes == null)
                return false;

            int idUser = Utils.Utils.TransformBytesToInt(bytes);
            string role = await roleController.Role(idUser);
            if (role == null || role != "Administrador")
                return false;

            return true;
        }

        private readonly ApplicationDbContext _context;
        private WithoutGenre setGenre;
        
        public PeliculasController(ApplicationDbContext context)
        {
            _context = context;
            setGenre = new WithoutGenre(_context);
            
        }

        // GET: Peliculas
        public async Task<IActionResult> Index()
        {
            if (!await Can())
                return NotFound("Solo admin");

            var filmGenres = from film in _context.tPelicula
                             join gp in _context.tGeneroPelicula on
                             film.cod_pelicula equals gp.cod_pelicula
                             join g in _context.tGenero on
                             gp.cod_genero equals g.cod_genero
                             select new FilmGenre(film, g, film.cod_pelicula);

            var list = await filmGenres.ToListAsync();
            var dicc = (from fg in list
                        group fg by fg.filmId into newList
                        select newList);

   

            return View(dicc.ToList());
        }

        public async Task<IActionResult> Dinero() 
        {
            if (!await Can())
                return NotFound("Solo admin");

            var films = from film in _context.tPelicula
                        select new Money(film, null, null);

            var afilms = await films.ToListAsync();

            foreach (var item in afilms)
            {
                item.buy = await (from buy in _context.ventaPermanente
                            where buy.filmId == item.film.cod_pelicula
                            select buy)
                            .ToListAsync();

                item.rent = await (from rent in _context.alquilerPermanente
                                   where rent.filmId == item.film.cod_pelicula
                                   select rent)
                                   .ToListAsync();
            }

            
            return View(afilms);

        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!await Can())
                return NotFound("Solo admin");
            if (id == null)
            {
                return NotFound();
            }

            var tPelicula = await _context.tPelicula
                .FirstOrDefaultAsync(m => m.cod_pelicula == id);
            if (tPelicula == null)
            {
                return NotFound();
            }

            return View(tPelicula);
        }

        // GET: Peliculas/Create
        public async  Task<IActionResult> Create()
        {
            if (!await Can())
                return NotFound("Solo admin");
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_pelicula,txt_desc,cant_disponibles_alquiler,cant_disponibles_venta,precio_alquiler,precio_venta")] tPelicula tPelicula)
        {
            if (!await Can())
                return NotFound("Solo admin");
            if (ModelState.IsValid)
            {
                _context.Add(tPelicula);
                await _context.SaveChangesAsync();
                await setGenre.Asign(tPelicula.cod_pelicula);
                return RedirectToAction(nameof(Index));
            }
            return View(tPelicula);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!await Can())
                return NotFound("Solo admin");
            if (id == null)
            {
                return NotFound();
            }

            var tPelicula = await _context.tPelicula.FindAsync(id);
            if (tPelicula == null)
            {
                return NotFound();
            }
            return View(tPelicula);
        }

        private async Task<IEnumerable<tGenero>> genresNotAssigned(int id) 
        {
            var genres = await _context.tGenero.ToListAsync();
            var genresOfThisFilm = await _context.tGeneroPelicula.Where(g => g.cod_pelicula == id).ToListAsync();
            var genresToAdd = genres.Where(g =>
            genresOfThisFilm.FirstOrDefault(gf =>
            gf.cod_genero == g.cod_genero) == null);

            return genresToAdd.ToList();
        }
        public async Task<IActionResult> AddGenre(int? id) 
        {
            if (!await Can())
                return NotFound("Solo admin");
            if (id == null)
                return NotFound();

           
            var film = await _context.tPelicula.FirstOrDefaultAsync(p => p.cod_pelicula == id);

            if (film == null)
                return NotFound();


            var genresToAdd = await genresNotAssigned((int)id);

            return View(new AddGenreToFilm(film, genresToAdd));
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(int? filmId, int? genreId) 
        {
            if (!await Can())
                return NotFound("Solo admin");

            if (filmId == null || genreId == null)
                return NotFound();

            var film = await _context.tPelicula.FirstOrDefaultAsync(p => p.cod_pelicula == filmId);
            var genre = await _context.tGenero.FirstOrDefaultAsync(g => g.cod_genero == genreId);

            if (film == null || genre == null)
                return NotFound();

            var genreFilm = await _context.tGeneroPelicula.FirstOrDefaultAsync(gf => gf.cod_genero == genreId && gf.cod_pelicula == filmId);
            if(genreFilm != null)
            {
                ViewBag.error = "La pelicula " + film.txt_desc + " ya tiene el genero " + genre.txt_desc + " asignado";
                var genresToAdd = await genresNotAssigned((int)filmId);
                return View(new AddGenreToFilm(film, genresToAdd));
            }

            var f = new SqlParameter("@filmId", filmId);
            var g = new SqlParameter("@genreId", genreId);

            await _context.tGeneroPelicula.FromSqlRaw("exec setGenreToThisFilm @filmId, @genreId", f, g).ToListAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_pelicula,txt_desc,cant_disponibles_alquiler,cant_disponibles_venta,precio_alquiler,precio_venta")] tPelicula tPelicula)
        {
            if (!await Can())
                return NotFound("Solo admin");

            if (id != tPelicula.cod_pelicula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tPelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tPeliculaExists(tPelicula.cod_pelicula))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tPelicula);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!await Can())
                return NotFound("Solo admin");

            if (id == null)
            {
                return NotFound();
            }

            var tPelicula = await _context.tPelicula
                .FirstOrDefaultAsync(m => m.cod_pelicula == id);
            if (tPelicula == null)
            {
                return NotFound();
            }

            return View(tPelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await Can())
                return NotFound("Solo admin");

            /*var tPelicula = await _context.tPelicula.FindAsync(id);
            _context.tPelicula.Remove(tPelicula);
            await _context.SaveChangesAsync();*/
            try { 
            await _context.tPelicula.FromSqlRaw("exec deleteFilm {0}", id).ToListAsync();
            }
            catch(Exception e) 
            {
                return NotFound("error");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool tPeliculaExists(int id)
        {
            return _context.tPelicula.Any(e => e.cod_pelicula == id);
        }
    }
}
