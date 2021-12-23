using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class setGenreToThisFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[setGenreToThisFilm]
                    (@filmId int,
                     @genreId int)  
                AS
                BEGIN
                     INSERT INTO tGeneroPelicula(cod_pelicula, cod_genero)
                                        VALUES (@filmId, @genreId);
                   SELECT * from tGeneroPelicula Where cod_pelicula = @filmId;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
