using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Migrations
{
    public partial class Movements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantidade",
                table: "Item",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 2)");

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemID = table.Column<int>(nullable: false),
                    Moment = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movements_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movements_ItemID",
                table: "Movements",
                column: "ItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantidade",
                table: "Item",
                type: "decimal(8, 2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
