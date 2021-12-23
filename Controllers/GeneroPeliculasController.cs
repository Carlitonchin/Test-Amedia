using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_Crud_Carlos_Arrieta.Data;
using Test_Crud_Carlos_Arrieta.Models;

namespace Test_Crud_Carlos_Arrieta.Controllers
{
    public class GeneroPeliculasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GeneroPeliculasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GeneroPeliculas
        public async Task<IActionResult> Index()
        {
            return View(await _context.tGeneroPelicula.ToListAsync());
        }

        // GET: GeneroPeliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tGeneroPelicula = await _context.tGeneroPelicula
                .FirstOrDefaultAsync(m => m.cod_genero_pelicula == id);
            if (tGeneroPelicula == null)
            {
                return NotFound();
            }

            return View(tGeneroPelicula);
        }

        // GET: GeneroPeliculas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneroPeliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_genero_pelicula,cod_pelicula,cod_genero")] tGeneroPelicula tGeneroPelicula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tGeneroPelicula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tGeneroPelicula);
        }

        // GET: GeneroPeliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tGeneroPelicula = await _context.tGeneroPelicula.FindAsync(id);
            if (tGeneroPelicula == null)
            {
                return NotFound();
            }
            return View(tGeneroPelicula);
        }

        // POST: GeneroPeliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_genero_pelicula,cod_pelicula,cod_genero")] tGeneroPelicula tGeneroPelicula)
        {
            if (id != tGeneroPelicula.cod_genero_pelicula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tGeneroPelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tGeneroPeliculaExists(tGeneroPelicula.cod_genero_pelicula))
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
            return View(tGeneroPelicula);
        }

        // GET: GeneroPeliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tGeneroPelicula = await _context.tGeneroPelicula
                .FirstOrDefaultAsync(m => m.cod_genero_pelicula == id);
            if (tGeneroPelicula == null)
            {
                return NotFound();
            }

            return View(tGeneroPelicula);
        }

        // POST: GeneroPeliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tGeneroPelicula = await _context.tGeneroPelicula.FindAsync(id);
            _context.tGeneroPelicula.Remove(tGeneroPelicula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tGeneroPeliculaExists(int id)
        {
            return _context.tGeneroPelicula.Any(e => e.cod_genero_pelicula == id);
        }
    }
}
