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

namespace Test_Crud_Carlos_Arrieta.Controllers
{
    public class GenerosController : Controller
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
        public GenerosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Generos
        public async Task<IActionResult> Index()
        {
            if (!await Can())
                return NotFound("Solo admin");
            return View(await _context.tGenero.ToListAsync());
        }

        // GET: Generos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!await Can())
                return NotFound("Solo admin");

            if (id == null)
            {
                return NotFound();
            }

            var tGenero = await _context.tGenero
                .FirstOrDefaultAsync(m => m.cod_genero == id);
            if (tGenero == null)
            {
                return NotFound();
            }

            return View(tGenero);
        }

        // GET: Generos/Create
        public async Task<IActionResult> Create()
        {
            if (!await Can())
                return NotFound("Solo admin");

            return View();
        }

        // POST: Generos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_genero,txt_desc")] tGenero tGenero)
        {
            if (!await Can())
                return NotFound("Solo admin");

            if (ModelState.IsValid)
            {
                _context.Add(tGenero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tGenero);
        }

        // GET: Generos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!await Can())
                return NotFound("Solo admin");

            if (id == null)
            {
                return NotFound();
            }

            var tGenero = await _context.tGenero.FindAsync(id);
            if (tGenero == null)
            {
                return NotFound();
            }
            return View(tGenero);
        }

        // POST: Generos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_genero,txt_desc")] tGenero tGenero)
        {
            if (!await Can())
                return NotFound("Solo admin");

            if (id != tGenero.cod_genero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tGenero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tGeneroExists(tGenero.cod_genero))
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
            return View(tGenero);
        }

        // GET: Generos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!await Can())
                return NotFound("Solo admin");

            if (id == null)
            {
                return NotFound();
            }

            var tGenero = await _context.tGenero
                .FirstOrDefaultAsync(m => m.cod_genero == id);
            if (tGenero == null)
            {
                return NotFound();
            }

            return View(tGenero);
        }

        // POST: Generos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await Can())
                return NotFound("Solo admin");

            var tGenero = await _context.tGenero.FindAsync(id);
            _context.tGenero.Remove(tGenero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tGeneroExists(int id)
        {
            return _context.tGenero.Any(e => e.cod_genero == id);
        }
    }
}
