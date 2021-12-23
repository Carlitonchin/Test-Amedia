using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test_Crud_Carlos_Arrieta.Controllers.Utils;
using Test_Crud_Carlos_Arrieta.Data;
using Test_Crud_Carlos_Arrieta.Models;
using Test_Crud_Carlos_Arrieta.Models.ViewModels;

namespace Test_Crud_Carlos_Arrieta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private RoleController roleController;
        private LoginController loginController;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            roleController = new RoleController(_context);
            loginController = new LoginController(_context);
        }

        public async Task<IActionResult> Index(int? codUser, int? closeSession)
        {
            if(closeSession != null) 
            {
                HttpContext.Session.Remove("user");
                return View();
            }
            

            byte[] bytes = null;
            HttpContext.Session.TryGetValue("user", out bytes);

            if (bytes != null)
                codUser = Utils.Utils.TransformBytesToInt(bytes);

            if (bytes == null && codUser == null)
                return View();

            if(codUser != null && bytes == null)
                bytes = BitConverter.GetBytes((int)codUser);

            
             HttpContext.Session.Set("user", bytes);

            try 
            {
                var result = await _context.tUsers.FromSqlRaw("execute getUserById {0}", codUser).ToListAsync();

                if (result.Count == 0)
                    return NotFound("error");

                var role = await roleController.Role(result[0]);

                if (role == null)
                    return NotFound("error");
                ViewBag.id = codUser;
                if (role == "Administrador") 
                    return View("admin", result[0]);
                
                if (role == "Visitante")
                    return View("visit", result[0]);

                return NotFound("error");

            }catch(Exception e) 
            {
                return NotFound("error");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if(userName == null || password == null) 
            {
                ViewBag.error = "por favor ingrese usuario y contraseña";
                return View();
            }

            var result = await loginController.Log(userName, password);
            if(result == null) 
            {
                ViewBag.error = "usuario o contraseña incorrectos";
                return View();
            }

            return RedirectToAction("Index", new { codUser = result.cod_usuario });
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
