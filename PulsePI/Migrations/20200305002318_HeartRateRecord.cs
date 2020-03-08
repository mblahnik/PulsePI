using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PulsePI.Migrations
{
    public partial class HeartRateRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "heartRateRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(nullable: false),
                    type = table.Column<string>(maxLength: 25, nullable: true),
                    startTime = table.Column<DateTime>(nullable: false),
                    endTime = table.Column<DateTime>(nullable: false),
                    bpmLow = table.Column<double>(nullable: false),
                    bpmHigh = table.Column<double>(nullable: false),
                    bpmAvg = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heartRateRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_heartRateRecords_accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_heartRateRecords_accountId",
                table: "heartRateRecords",
                column: "accountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "heartRateRecords");
        }
    }
}
