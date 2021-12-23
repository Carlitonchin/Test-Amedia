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
    public class VentasController : Controller
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

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            if (!await Can())
                return NotFound("solo admin");

            return View(await _context.tPelicula.Where(p => p.cant_disponibles_venta > 0).ToListAsync());
        }

        public async Task<IActionResult> Comprar(int? filmId) 
        {
            if (!await Can())
                return NotFound("solo admin");

            if (filmId == null)
            {
                return NotFound();
            }

            var film = await _context.tPelicula.FirstOrDefaultAsync(p => p.cod_pelicula == filmId);

            if (film == null)
                return NotFound();

            if (film.cant_disponibles_venta == 0)
            {
                ViewBag.error = "No hay disponibilidad";
                return View("Index");
            }

            byte[] bytes = null;
            HttpContext.Session.TryGetValue("user", out bytes);
            int idUser = Utils.Utils.TransformBytesToInt(bytes);
            film.cant_disponibles_venta--;
            _context.tPelicula.Update(film);
            _context.tVenta.Add(new tVenta()
            {
                cod_pelicula = film.cod_pelicula,
                cod_usuario = idUser,
                momento = DateTime.Now,
                precio = film.precio_venta
                
            });

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MisCompras() 
        {
            if (!await Can())
                return NotFound("solo admin");

            byte[] bytes = null;
            HttpContext.Session.TryGetValue("user", out bytes);
            int idUser = Utils.Utils.TransformBytesToInt(bytes);

            var compras = await _context.tVenta.Where(a => a.cod_usuario == idUser).ToListAsync();
            var filmBuy = (from a in compras
                            join film in _context.tPelicula on
                              a.cod_pelicula equals film.cod_pelicula
                            select new BuyFilm(film, a)).ToList();


            return View(filmBuy);
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVenta = await _context.tVenta
                .FirstOrDefaultAsync(m => m.cod_venta == id);
            if (tVenta == null)
            {
                return NotFound();
            }

            return View(tVenta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_venta,precio,momento,cod_usuario,cod_pelicula")] tVenta tVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tVenta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVenta = await _context.tVenta.FindAsync(id);
            if (tVenta == null)
            {
                return NotFound();
            }
            return View(tVenta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_venta,precio,momento,cod_usuario,cod_pelicula")] tVenta tVenta)
        {
            if (id != tVenta.cod_venta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tVentaExists(tVenta.cod_venta))
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
            return View(tVenta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVenta = await _context.tVenta
                .FirstOrDefaultAsync(m => m.cod_venta == id);
            if (tVenta == null)
            {
                return NotFound();
            }

            return View(tVenta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tVenta = await _context.tVenta.FindAsync(id);
            _context.tVenta.Remove(tVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tVentaExists(int id)
        {
            return _context.tVenta.Any(e => e.cod_venta == id);
        }
    }
}
