using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class roltablecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tRol",
                columns: table => new
                {
                    cod_rol = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_desc = table.Column<string>(nullable: true),
                    sn_activo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tRol", x => x.cod_rol);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tRol");
        }
    }
}
