using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Data.Migrations
{
    public partial class ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "AspNetUsers",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "Nome");
        }
    }
}
