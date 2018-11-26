using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Data.Migrations
{
    public partial class lorem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.RenameColumn(
                name: "Username",
                table: "Volunteer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "Email");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.RenameColumn(
                name: "Email",
                table: "Volunteer",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AspNetUsers",
                newName: "UserName");*/
        }
    }
}
