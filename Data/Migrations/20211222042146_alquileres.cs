using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class alquileres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tPelicula",
                columns: table => new
                {
                    cod_pelicula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_desc = table.Column<string>(maxLength: 500, nullable: true),
                    cant_disponibles_alquiler = table.Column<int>(nullable: false),
                    cant_disponibles_venta = table.Column<int>(nullable: false),
                    precio_alquiler = table.Column<decimal>(nullable: false),
                    precio_venta = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPelicula", x => x.cod_pelicula);
                });

            migrationBuilder.CreateTable(
                name: "tAlquiler",
                columns: table => new
                {
                    cod_adquiler = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_tAlquiler", x => x.cod_adquiler);
                    table.ForeignKey(
                        name: "FK_tAlquiler_tPelicula_peliculacod_pelicula",
                        column: x => x.peliculacod_pelicula,
                        principalTable: "tPelicula",
                        principalColumn: "cod_pelicula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tAlquiler_tUsers_usuariocod_usuario",
                        column: x => x.usuariocod_usuario,
                        principalTable: "tUsers",
                        principalColumn: "cod_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tAlquiler_peliculacod_pelicula",
                table: "tAlquiler",
                column: "peliculacod_pelicula");

            migrationBuilder.CreateIndex(
                name: "IX_tAlquiler_usuariocod_usuario",
                table: "tAlquiler",
                column: "usuariocod_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tAlquiler");

            migrationBuilder.DropTable(
                name: "tPelicula");
        }
    }
}
