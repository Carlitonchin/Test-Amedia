using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class deleteFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[deleteFilm]
                    @id int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    UPDATE tPelicula
                    SET cant_disponibles_alquiler = 0, cant_disponibles_venta = 0
                    WHERE cod_pelicula = @id;

                    SELECT * FROM tPelicula
                    WHERE cod_pelicula = @id;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
