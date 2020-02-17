using Microsoft.EntityFrameworkCore.Migrations;

namespace PulsePI.Migrations
{
    public partial class addHeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "height",
                table: "accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "weight",
                table: "accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "height",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "accounts");
        }
    }
}
