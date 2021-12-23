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

namespace Test_Crud_Carlos_Arrieta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private RoleController roleController;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            roleController = new RoleController(_context);
        }

        public async Task<IActionResult> Index(int? codUser)
        {
            if(codUser == null)
                return View();

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
