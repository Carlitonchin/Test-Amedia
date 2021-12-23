using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Crud_Carlos_Arrieta.Models;

namespace Test_Crud_Carlos_Arrieta.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Test_Crud_Carlos_Arrieta.Models.tRol> tRol { get; set; }
        public DbSet<Test_Crud_Carlos_Arrieta.Models.tAlquiler> tAlquiler { get; set; }
        public DbSet<Test_Crud_Carlos_Arrieta.Models.tGenero> tGenero { get; set; }
        public DbSet<Test_Crud_Carlos_Arrieta.Models.tGeneroPelicula> tGeneroPelicula { get; set; }
        public DbSet<Test_Crud_Carlos_Arrieta.Models.tPelicula> tPelicula { get; set; }
        public DbSet<Test_Crud_Carlos_Arrieta.Models.tUsers> tUsers { get; set; }
        public DbSet<Test_Crud_Carlos_Arrieta.Models.tVenta> tVenta { get; set; }
        public DbSet<Test_Crud_Carlos_Arrieta.Models.VentaPermanente> ventaPermanente { get; set; }
        public DbSet<Test_Crud_Carlos_Arrieta.Models.AlquilerPermanente> alquilerPermanente { get; set; }
    }
}
