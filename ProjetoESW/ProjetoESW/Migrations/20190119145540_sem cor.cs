using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Migrations
{
    public partial class semcor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Color_ColorID",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Animal_ColorID",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Colony");

            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "Animal");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Animal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Animal");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Colony",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorID",
                table: "Animal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ColorID",
                table: "Animal",
                column: "ColorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Color_ColorID",
                table: "Animal",
                column: "ColorID",
                principalTable: "Color",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
