using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Migrations
{
    public partial class Accounting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounting",
                columns: table => new
                {
                    AccountingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting", x => x.AccountingID);
                });

            migrationBuilder.CreateTable(
                name: "AccountMovements",
                columns: table => new
                {
                    AccountMovementsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountingID = table.Column<int>(nullable: false),
                    Ammount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountMovements", x => x.AccountMovementsID);
                    table.ForeignKey(
                        name: "FK_AccountMovements_Accounting_AccountingID",
                        column: x => x.AccountingID,
                        principalTable: "Accounting",
                        principalColumn: "AccountingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountMovements_AccountingID",
                table: "AccountMovements",
                column: "AccountingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountMovements");

            migrationBuilder.DropTable(
                name: "Accounting");
        }
    }
}
