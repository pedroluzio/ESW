using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Migrations
{
    public partial class itemchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemType_ItemTypeID",
                table: "Item");

            migrationBuilder.AlterColumn<double>(
                name: "Quantidade",
                table: "Item",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeID",
                table: "Item",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemType_ItemTypeID",
                table: "Item",
                column: "ItemTypeID",
                principalTable: "ItemType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemType_ItemTypeID",
                table: "Item");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantidade",
                table: "Item",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeID",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemType_ItemTypeID",
                table: "Item",
                column: "ItemTypeID",
                principalTable: "ItemType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
