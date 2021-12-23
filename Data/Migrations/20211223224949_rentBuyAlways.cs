using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class rentBuyAlways : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alquilerPermanente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filmId = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alquilerPermanente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ventaPermanente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filmId = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventaPermanente", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alquilerPermanente");

            migrationBuilder.DropTable(
                name: "ventaPermanente");
        }
    }
}
