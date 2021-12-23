using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class notContainThisGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[notContainThisGenre]
                    (@filmId int,
                     @genreId int)  
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from tGeneroPelicula
                    WHERE cod_pelicula = @filmId and cod_genero = @genreId;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
