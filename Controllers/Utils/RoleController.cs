using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Crud_Carlos_Arrieta.Data;
using Test_Crud_Carlos_Arrieta.Models;

namespace Test_Crud_Carlos_Arrieta.Controllers.Utils
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Role(tUsers user) 
        {
            try 
            {
               var role = await _context.tRol.FromSqlRaw("exec getRoleById {0}", user.cod_rol).ToListAsync();
                if (role.Count == 0)
                    return null;

                return role[0].txt_desc;

            }catch(Exception e) 
            {
                return null;
            }

            return null;
        }
    }
}
