using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Migrations
{
    public partial class itemchange1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantidade",
                table: "Item",
                type: "decimal(8, 2)",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantidade",
                table: "Item",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 2)");
        }
    }
}
