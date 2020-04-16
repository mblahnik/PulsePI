using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PulsePI.Migrations
{
    public partial class Adddobtobiometric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dob",
                table: "biometrics",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dob",
                table: "biometrics");
        }
    }
}
