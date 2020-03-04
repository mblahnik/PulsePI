using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PulsePI.Migrations
{
    public partial class GuidForAccntId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "accounts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
