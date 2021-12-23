using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class genero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tGenero",
                columns: table => new
                {
                    cod_genero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_desc = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tGenero", x => x.cod_genero);
                });

            migrationBuilder.CreateTable(
                name: "tGeneroPelicula",
                columns: table => new
                {
                    cod_genero_pelicula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_pelicula = table.Column<int>(nullable: false),
                    peliculacod_pelicula = table.Column<int>(nullable: true),
                    cod_genero = table.Column<int>(nullable: false),
                    generocod_genero = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tGeneroPelicula", x => x.cod_genero_pelicula);
                    table.ForeignKey(
                        name: "FK_tGeneroPelicula_tGenero_generocod_genero",
                        column: x => x.generocod_genero,
                        principalTable: "tGenero",
                        principalColumn: "cod_genero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tGeneroPelicula_tPelicula_peliculacod_pelicula",
                        column: x => x.peliculacod_pelicula,
                        principalTable: "tPelicula",
                        principalColumn: "cod_pelicula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tGeneroPelicula_generocod_genero",
                table: "tGeneroPelicula",
                column: "generocod_genero");

            migrationBuilder.CreateIndex(
                name: "IX_tGeneroPelicula_peliculacod_pelicula",
                table: "tGeneroPelicula",
                column: "peliculacod_pelicula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tGeneroPelicula");

            migrationBuilder.DropTable(
                name: "tGenero");
        }
    }
}
