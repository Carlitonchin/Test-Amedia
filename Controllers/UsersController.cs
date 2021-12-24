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

namespace Test_Crud_Carlos_Arrieta.Controllers
{
    public class UsersController : Controller
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
        
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string error)
        {
            if (!await Can())
                return NotFound("Solo admin");

            byte[] bytes = null;
            HttpContext.Session.TryGetValue("user", out bytes);
            int idUser = Utils.Utils.TransformBytesToInt(bytes);

            if (error != null)
                ViewBag.error = error;
            return View(await _context.tUsers.Where(m=>m.cod_usuario != idUser).ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!await Can())
                return NotFound("Solo admin");
            if (id == null)
            {
                return NotFound();
            }

            var tUsers = await _context.tUsers
                .FirstOrDefaultAsync(m => m.cod_usuario == id);
            if (tUsers == null)
            {
                return NotFound();
            }

            return View(tUsers);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var rols = _context.tRol.ToList();
            ViewBag.rols = rols;
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_usuario,txt_user,txt_password,txt_nombre,txt_apellido,nro_doc,sn_activo,cod_rol")] tUsers tUsers)
        {
            try
            {
                var user = await _context.tUsers.FromSqlRaw("exec DocumentExist {0}", tUsers.nro_doc).ToListAsync();
            
            if(user.Count > 0)
            {
                ViewBag.exist = true;
                var rols = _context.tRol.ToList();
                ViewBag.rols = rols;
                return View(tUsers);
            }

            if (ModelState.IsValid)
            {
                var userName = new SqlParameter("@userName", tUsers.txt_user);
                var password = new SqlParameter("@password", tUsers.txt_password);
                var name = new SqlParameter("@name", tUsers.txt_nombre);
                var lastName = new SqlParameter("@lastName", tUsers.txt_apellido);
                var noDocument = new SqlParameter("@noDocument", tUsers.nro_doc);
                var active = new SqlParameter("@active", tUsers.sn_activo);
                var rol = new SqlParameter("@rol", tUsers.cod_rol);

                 
               var result = await _context.tUsers.FromSqlRaw("exec createUser @userName, @password, @name, @lastName, @noDocument, @active, @rol",
userName, password, name, lastName, noDocument, active, rol).ToListAsync();

                    if (result.Count == 0)
                        return NotFound("ocurrio algun error");

                return RedirectToAction("Index", "Home", new { codUser=result[0].cod_usuario});
                
            }
                }catch (Exception e)
                 {
                    //cambiar
                    return NotFound("ocurrio algun error");
                 }

            return View(tUsers);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!await Can())
                return NotFound("Solo admin");
            if (id == null)
            {
                return NotFound();
            }

            var tUsers = await _context.tUsers.FindAsync(id);
            if (tUsers == null)
            {
                return NotFound();
            }
            return View(tUsers);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_usuario,txt_user,txt_password,txt_nombre,txt_apellido,nro_doc,sn_activo,cod_rol")] tUsers tUsers)
        {
            if (!await Can())
                return NotFound("Solo admin");
            if (id != tUsers.cod_usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.SaveChangesAsync();
                    _context.Update(tUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tUsersExists(tUsers.cod_usuario))
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
            return View(tUsers);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!await Can())
                return NotFound("Solo admin");
            if (id == null)
            {
                return NotFound();
            }

            var tUsers = await _context.tUsers
                .FirstOrDefaultAsync(m => m.cod_usuario == id);
            if (tUsers == null)
            {
                return NotFound();
            }

            return View(tUsers);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await Can())
                return NotFound("Solo admin");

            bool debePeliculas = await _context.tAlquiler.FirstOrDefaultAsync(m => m.cod_usuario == id) != null;

            

            var tUsers = await _context.tUsers.FindAsync(id);

            if (debePeliculas)
            {
                string error = "No puedes eliminar a " + tUsers.txt_user + ", debe peliculas";
                return RedirectToAction(nameof(Index), new { error = error });
            }

            _context.tUsers.Remove(tUsers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tUsersExists(int id)
        {
            return _context.tUsers.Any(e => e.cod_usuario == id);
        }
    }
}
