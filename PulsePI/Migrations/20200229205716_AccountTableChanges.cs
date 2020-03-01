using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PulsePI.Migrations
{
    public partial class AccountTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "height",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "accounts");

            migrationBuilder.AddColumn<string>(
                name: "avatarUrl",
                table: "accounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthDate",
                table: "accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "middleName",
                table: "accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatarUrl",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "middleName",
                table: "accounts");

            migrationBuilder.AddColumn<int>(
                name: "height",
                table: "accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "weight",
                table: "accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
