using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Data
{
    public static class ContextSeed
    {
        public static async Task createBase(ApplicationDbContext context) 
        {
            if(context.tRol != null && context.tRol.ToList().Count == 0) { 
            context.tRol.Add(new Models.tRol() { txt_desc = "Administrador" });
            context.tRol.Add(new Models.tRol() { txt_desc = "Visitante" });
            }
            if(context.tGenero != null && context.tGenero.ToList().Count == 0) { 
            context.tGenero.Add(new Models.tGenero() { txt_desc = "Sin Genero" });
            }
            await context.SaveChangesAsync();
            }
    }
}
