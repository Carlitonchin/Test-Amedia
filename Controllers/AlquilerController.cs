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
    public class AlquilerController : Controller
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

        public AlquilerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alquiler
        public async Task<IActionResult> Index()
        {
            if (!await Can())
                return NotFound("solo admin");

            return View(await _context.tPelicula.Where(p=>p.cant_disponibles_alquiler > 0).ToListAsync());
        }

        public async Task<IActionResult> Alquilar(int? filmId) 
        {
            if (!await Can())
                return NotFound("solo admin");

            if(filmId == null) 
            {
                return NotFound();
            }

            var film = await _context.tPelicula.FirstOrDefaultAsync(p => p.cod_pelicula == filmId);

            if (film == null)
                return NotFound();

            if(film.cant_disponibles_alquiler == 0)
            {
                ViewBag.error = "No hay disponibilidad";
                return View("Index");
            }

            byte[] bytes = null;
            HttpContext.Session.TryGetValue("user", out bytes);
            int idUser = Utils.Utils.TransformBytesToInt(bytes);
            film.cant_disponibles_alquiler--;
            _context.tPelicula.Update(film);
            _context.tAlquiler.Add(new tAlquiler() 
            {
                cod_pelicula = film.cod_pelicula,
                cod_usuario = idUser,
                momento = DateTime.Now,
                precio = film.precio_alquiler
            });

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Devolver() 
        {
            if (!await Can())
                return NotFound("solo admin");

            byte[] bytes = null;
            HttpContext.Session.TryGetValue("user", out bytes);
            int idUser = Utils.Utils.TransformBytesToInt(bytes);

            var alquileres = await _context.tAlquiler.Where(a => a.cod_usuario == idUser).ToListAsync();
            var filmRent = (from a in alquileres
                           join film in _context.tPelicula on
                             a.cod_pelicula equals film.cod_pelicula
                           select new RentFilm(film, a)).ToList();


            return View(filmRent);
        }

        public async Task<IActionResult> DevolverFinal(int? rentId)
        {
            if (!await Can())
                return NotFound("solo admin");

            if (rentId == null)
                return NotFound();

            var rent = await _context.tAlquiler.FirstOrDefaultAsync(a => a.cod_adquiler == rentId);

            if (rent == null)
                return NotFound();

            _context.tAlquiler.Remove(rent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Devolver));

        }

        public async Task<IActionResult> Alquiladas() 
        {
            if (!await Can())
                return NotFound("solo admin");

            var rents = await _context.tAlquiler.ToListAsync();

            var rentsUser = from ru in (from rent in rents
                                        join user in _context.tUsers on
                                         rent.cod_usuario equals user.cod_usuario
                                         join film in _context.tPelicula on
                                         rent.cod_pelicula equals film.cod_pelicula
                                        select new RentUser(film, user, user.cod_usuario))
                                        group ru by ru.userId into dict
                                         select dict;

            var r = rentsUser.ToList();
            return View(r);
                            
        }

            // GET: Alquiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAlquiler = await _context.tAlquiler
                .FirstOrDefaultAsync(m => m.cod_adquiler == id);
            if (tAlquiler == null)
            {
                return NotFound();
            }

            return View(tAlquiler);
        }

        // GET: Alquiler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alquiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_adquiler,precio,momento,cod_usuario,cod_pelicula")] tAlquiler tAlquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tAlquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tAlquiler);
        }

        // GET: Alquiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAlquiler = await _context.tAlquiler.FindAsync(id);
            if (tAlquiler == null)
            {
                return NotFound();
            }
            return View(tAlquiler);
        }

        // POST: Alquiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_adquiler,precio,momento,cod_usuario,cod_pelicula")] tAlquiler tAlquiler)
        {
            if (id != tAlquiler.cod_adquiler)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tAlquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tAlquilerExists(tAlquiler.cod_adquiler))
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
            return View(tAlquiler);
        }

        // GET: Alquiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAlquiler = await _context.tAlquiler
                .FirstOrDefaultAsync(m => m.cod_adquiler == id);
            if (tAlquiler == null)
            {
                return NotFound();
            }

            return View(tAlquiler);
        }

        // POST: Alquiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tAlquiler = await _context.tAlquiler.FindAsync(id);
            _context.tAlquiler.Remove(tAlquiler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tAlquilerExists(int id)
        {
            return _context.tAlquiler.Any(e => e.cod_adquiler == id);
        }
    }
}
