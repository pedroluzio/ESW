using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Migrations
{
    public partial class accountgmovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AccountMovements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AccountMovements");
        }
    }
}
