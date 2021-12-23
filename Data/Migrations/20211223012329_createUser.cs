using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class createUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[createUser]
                    (@userName varchar(50),
                    @password varchar(50),
                    @name varchar(200),
                    @lastName varchar(200),
                    @noDocument varchar(50),
                    @active int,
                    @rol int)
                AS
                BEGIN
                    INSERT INTO tUsers(txt_user, txt_password, txt_nombre, txt_apellido, nro_doc, sn_activo, cod_rol)
                                        VALUES ( @userName, @password, @name, @lastName, @noDocument, @active,@rol);
                   SELECT * from tUsers Where nro_doc = @noDocument;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
