using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceProcessor.Infrastructure.Migrations
{
    public partial class addSubscriptionRatesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionRatesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubscriptionRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionPrice = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<TimeSpan>(type: "time", nullable: false),
                    IntervalUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCycles = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalPeriod = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionRates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SubscriptionRatesId",
                table: "AspNetUsers",
                column: "SubscriptionRatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SubscriptionRates_SubscriptionRatesId",
                table: "AspNetUsers",
                column: "SubscriptionRatesId",
                principalTable: "SubscriptionRates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SubscriptionRates_SubscriptionRatesId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubscriptionRates");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SubscriptionRatesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionRatesId",
                table: "AspNetUsers");
        }
    }
}
