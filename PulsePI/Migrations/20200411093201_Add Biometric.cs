using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PulsePI.Migrations
{
    public partial class AddBiometric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "biometrics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(nullable: false),
                    height = table.Column<double>(maxLength: 25, nullable: false),
                    weight = table.Column<double>(nullable: false),
                    sex = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biometrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_biometrics_accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_biometrics_accountId",
                table: "biometrics",
                column: "accountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "biometrics");
        }
    }
}
