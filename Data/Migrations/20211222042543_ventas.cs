using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class ventas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tVenta",
                columns: table => new
                {
                    cod_venta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(nullable: false),
                    momento = table.Column<DateTime>(nullable: false),
                    cod_usuario = table.Column<int>(nullable: false),
                    usuariocod_usuario = table.Column<int>(nullable: true),
                    cod_pelicula = table.Column<int>(nullable: false),
                    peliculacod_pelicula = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tVenta", x => x.cod_venta);
                    table.ForeignKey(
                        name: "FK_tVenta_tPelicula_peliculacod_pelicula",
                        column: x => x.peliculacod_pelicula,
                        principalTable: "tPelicula",
                        principalColumn: "cod_pelicula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tVenta_tUsers_usuariocod_usuario",
                        column: x => x.usuariocod_usuario,
                        principalTable: "tUsers",
                        principalColumn: "cod_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tVenta_peliculacod_pelicula",
                table: "tVenta",
                column: "peliculacod_pelicula");

            migrationBuilder.CreateIndex(
                name: "IX_tVenta_usuariocod_usuario",
                table: "tVenta",
                column: "usuariocod_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tVenta");
        }
    }
}
