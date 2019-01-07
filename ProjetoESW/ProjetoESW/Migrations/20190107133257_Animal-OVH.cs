using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Migrations
{
    public partial class AnimalOVH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OVHID",
                table: "Animal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OVH",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVH", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    AnimalID = table.Column<int>(nullable: true),
                    OVHID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointment_Animal_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_OVH_OVHID",
                        column: x => x.OVHID,
                        principalTable: "OVH",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_OVHID",
                table: "Animal",
                column: "OVHID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AnimalID",
                table: "Appointment",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_OVHID",
                table: "Appointment",
                column: "OVHID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_OVH_OVHID",
                table: "Animal",
                column: "OVHID",
                principalTable: "OVH",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_OVH_OVHID",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "OVH");

            migrationBuilder.DropIndex(
                name: "IX_Animal_OVHID",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "OVHID",
                table: "Animal");
        }
    }
}
