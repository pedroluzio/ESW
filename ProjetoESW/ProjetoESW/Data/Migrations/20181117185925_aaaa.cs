using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoESW.Data.Migrations
{
    public partial class aaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Regist",
                table: "Volunteer",
                nullable: true,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Regist",
                table: "Volunteer",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValueSql: "getutcdate()");
        }
    }
}
