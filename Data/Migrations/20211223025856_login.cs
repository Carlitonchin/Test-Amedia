using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Crud_Carlos_Arrieta.Data.Migrations
{
    public partial class login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[login]
                    (@userName varchar(50),
                      @password varchar(50))
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from tUsers where (txt_user = @userName and txt_password = @password);
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
