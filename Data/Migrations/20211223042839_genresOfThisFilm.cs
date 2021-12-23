using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class genresOfThisFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[genresOfThisFilm]
                    @id int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from
                    tPelicula
                    INNER JOIN tGeneroPelicula
                    ON tGeneroPelicula.cod_pelicula = tPelicula.cod_pelicula
                    INNER JOIN tGenero ON
                    tGenero.cod_genero = tGeneroPelicula.cod_genero
                    WHERE tGeneroPelicula.cod_pelicula = @id;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
