using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class tableUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "txt_desc",
                table: "tRol",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tUsers",
                columns: table => new
                {
                    cod_usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_user = table.Column<string>(maxLength: 50, nullable: true),
                    txt_password = table.Column<string>(maxLength: 50, nullable: true),
                    txt_nombre = table.Column<string>(maxLength: 200, nullable: true),
                    txt_apellido = table.Column<string>(maxLength: 200, nullable: true),
                    nro_doc = table.Column<string>(maxLength: 50, nullable: false),
                    sn_activo = table.Column<int>(nullable: false),
                    cod_rol = table.Column<int>(nullable: false),
                    trolcod_rol = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUsers", x => x.cod_usuario);
                    table.ForeignKey(
                        name: "FK_tUsers_tRol_trolcod_rol",
                        column: x => x.trolcod_rol,
                        principalTable: "tRol",
                        principalColumn: "cod_rol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tUsers_trolcod_rol",
                table: "tUsers",
                column: "trolcod_rol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tUsers");

            migrationBuilder.AlterColumn<string>(
                name: "txt_desc",
                table: "tRol",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
