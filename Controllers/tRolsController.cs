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
    public class tRolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tRolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tRols
        public async Task<IActionResult> Index()
        {
            return View(await _context.tRol.ToListAsync());
        }

        // GET: tRols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tRol = await _context.tRol
                .FirstOrDefaultAsync(m => m.cod_rol == id);
            if (tRol == null)
            {
                return NotFound();
            }

            return View(tRol);
        }

        // GET: tRols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tRols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_rol,txt_desc,sn_activo")] tRol tRol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tRol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tRol);
        }

        // GET: tRols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tRol = await _context.tRol.FindAsync(id);
            if (tRol == null)
            {
                return NotFound();
            }
            return View(tRol);
        }

        // POST: tRols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_rol,txt_desc,sn_activo")] tRol tRol)
        {
            if (id != tRol.cod_rol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tRol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tRolExists(tRol.cod_rol))
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
            return View(tRol);
        }

        // GET: tRols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tRol = await _context.tRol
                .FirstOrDefaultAsync(m => m.cod_rol == id);
            if (tRol == null)
            {
                return NotFound();
            }

            return View(tRol);
        }

        // POST: tRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tRol = await _context.tRol.FindAsync(id);
            _context.tRol.Remove(tRol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tRolExists(int id)
        {
            return _context.tRol.Any(e => e.cod_rol == id);
        }
    }
}
