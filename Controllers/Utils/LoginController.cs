using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Crud_Carlos_Arrieta.Data;
using Test_Crud_Carlos_Arrieta.Models;

namespace Test_Crud_Carlos_Arrieta.Controllers.Utils
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<tUsers> Log(string userName, string password) 
        {
            try 
            {
                var user = new SqlParameter("@userName", userName);
                var pass = new SqlParameter("@password", password);
                var users = await _context.tUsers.FromSqlRaw("exec login @userName, @password", user, pass).ToListAsync();
                if (users == null || users.Count == 0)
                    return null;

                return users[0];
            }
            catch(Exception e) 
            {
                return null;
            }

            return null;
        } 
    }
}
