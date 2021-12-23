using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_Crud_Carlos_Arrieta.Controllers.Utils;
using Test_Crud_Carlos_Arrieta.Data;
using Test_Crud_Carlos_Arrieta.Models;
using Test_Crud_Carlos_Arrieta.Models.ViewModels;

namespace Test_Crud_Carlos_Arrieta.Controllers
{
    public class PeliculasController : Controller
    {
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

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_pelicula,txt_desc,cant_disponibles_alquiler,cant_disponibles_venta,precio_alquiler,precio_venta")] tPelicula tPelicula)
        {
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

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_pelicula,txt_desc,cant_disponibles_alquiler,cant_disponibles_venta,precio_alquiler,precio_venta")] tPelicula tPelicula)
        {
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
